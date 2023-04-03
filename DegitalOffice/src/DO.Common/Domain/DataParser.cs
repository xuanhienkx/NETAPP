using DO.Common.Contract;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DO.Common.Domain
{
    /// <summary>
    /// https://github.com/garvincasimir/csharp-datatables-parser.git
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Parser<T> where T : class
    {
        private IQueryable<T> queryable;
        private readonly Dictionary<string, string> config;
        private readonly Type type;
        private readonly IDictionary<int, PropertyMap> propertyMap;

        //Global configs
        private readonly int take;
        private readonly int skip;
        private readonly bool sortDisabled;

        private readonly Dictionary<string, Expression> converters = new Dictionary<string, Expression>();

        private readonly Type[] convertable =
        {
            typeof(int),
            typeof(int?),
            typeof(decimal),
            typeof(decimal?),
            typeof(float),
            typeof(float?),
            typeof(double),
            typeof(double?),
            typeof(DateTime),
            typeof(DateTime?)
        };

        public Parser(IEnumerable<KeyValuePair<string, string>> configParams, IQueryable<T> queryable)
        {
            this.queryable = queryable;
            config = configParams.ToDictionary(k => k.Key, v => v.Value?.Trim());
            type = typeof(T);

            //This associates class properties with corresponding datatable configuration options
            propertyMap = (from param in config
                           join prop in type.GetProperties() on param.Value equals prop.Name
                           where Regex.IsMatch(param.Key, DataParserConstants.ColumnPropertyPattern)
                           let index = Regex.Match(param.Key, DataParserConstants.ColumnPropertyPattern).Groups[1].Value
                           let searchableKey = DataParserConstants.GetKey(DataParserConstants.SearchablePropertyFormat, index)
                           let searchable = config.ContainsKey(searchableKey) && config[searchableKey] == Boolean.TrueString
                           let orderableKey = DataParserConstants.GetKey(DataParserConstants.OrderablePropertyFormat, index)
                           let orderable = config.ContainsKey(orderableKey) && config[orderableKey] == Boolean.TrueString
                           let filterKey = DataParserConstants.GetKey(DataParserConstants.SearchValuePropertyFormat, index)
                           let filter = config.ContainsKey(filterKey) ? config[filterKey] : string.Empty
                           // Set regex when implemented

                           select new
                           {
                               index = int.Parse(index),
                               map = new PropertyMap
                               {
                                   Property = prop,
                                   Searchable = searchable,
                                   Orderable = orderable,
                                   Filter = filter
                               }
                           }).Distinct().ToDictionary(k => k.index, v => v.map);


            int.TryParse(config[DataParserConstants.Start], out skip);
            int.TryParse(config[DataParserConstants.Length], out take);
            sortDisabled = config.ContainsKey(DataParserConstants.OrderingEnabled) &&
                           config[DataParserConstants.OrderingEnabled] == "false";
        }

        public Results<T> Parse()
        {
            var list = new Results<T>();

            // parse the echo property
            //list.Draw = int.Parse(config[Constants.Draw]);

            // count the record BEFORE filtering
            //list.RecordsTotal = queryable.Count();

            //sort results if sorting isn't disabled or skip needs to be called
            if (!sortDisabled || skip > 0)
            {
                ApplySort();
            }


            IEnumerable<T> resultQuery;
            var hasFilterText = !string.IsNullOrWhiteSpace(config[DataParserConstants.SearchKey]) ||
                                propertyMap.Any(p => !string.IsNullOrWhiteSpace(p.Value.Filter));
            //Use query expression to return filtered paged list
            //This is a best effort to avoid client evaluation whenever possible
            //No good api to determine support for .ToString() on a type
            if (queryable.Provider is EnumerableQuery && hasFilterText)
            {
                resultQuery = queryable.AsEnumerable().Where(EnumerablFilter)
                    .Skip(skip)
                    .Take(take);

                list.RecordsFiltered = queryable.Count(EnumerablFilter);
            }
            else if (hasFilterText)
            {
                var entityFilter = GenerateEntityFilter();
                resultQuery = queryable.Where(entityFilter)
                    .Skip(skip)
                    .Take(take);

                list.RecordsFiltered = queryable.Count(entityFilter);
            }
            else
            {
                resultQuery = queryable
                    .Skip(skip)
                    .Take(take);

                list.RecordsFiltered = queryable.Count();
            }


            list.Data = resultQuery.ToList();

            return list;
        }

        ///<summary>
        /// SetConverter accepts a custom expression for converting a property in T to string. 
        /// This will be used during filtering. 
        ///</summary>
        /// <param name="property">A lambda expression with a member expression as the body</param>
        /// <param name="tostring">A lambda given T returns a string by performing a sql translatable operation on property</param>
        public Parser<T> SetConverter(Expression<Func<T, object>> property, Expression<Func<T, string>> tostring)
        {
            var propertyName = property.GetPropertyName();
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Body in property must be a member expression");

            converters[propertyName] = tostring.Body;

            return this;
        }

        private void ApplySort()
        {
            var sorted = false;
            var paramExpr = Expression.Parameter(type, "val");

            // Enumerate the keys sort keys in the order we received them
            foreach (var param in config.Where(k => Regex.IsMatch(k.Key, DataParserConstants.OrderPattern)))
            {
                // column number to sort (same as the array)
                var sortcolumn = int.Parse(param.Value);

                // ignore disabled columns 
                if (!propertyMap.ContainsKey(sortcolumn) || !propertyMap[sortcolumn].Orderable)
                {
                    continue;
                }

                var index = Regex.Match(param.Key, DataParserConstants.OrderPattern).Groups[1].Value;
                var orderDirectionKey = DataParserConstants.GetKey(DataParserConstants.OrderDirectionFormat, index);

                // get the direction of the sort
                var sortdir = config[orderDirectionKey];


                var sortProperty = propertyMap[sortcolumn].Property;
                var expression1 = Expression.Property(paramExpr, sortProperty);
                var propType = sortProperty.PropertyType;
                var delegateType = Expression.GetFuncType(type, propType);
                var propertyExpr = Expression.Lambda(delegateType, expression1, paramExpr);

                // apply the sort (default is ascending if not specified)
                string methodName;
                if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(DataParserConstants.AscendingSort,
                        StringComparison.OrdinalIgnoreCase))
                {
                    methodName = sorted ? "ThenBy" : "OrderBy";
                }
                else
                {
                    methodName = sorted ? "ThenByDescending" : "OrderByDescending";
                }

                queryable = typeof(Queryable).GetMethods().Single(
                        method => method.Name == methodName
                                  && method.IsGenericMethodDefinition
                                  && method.GetGenericArguments().Length == 2
                                  && method.GetParameters().Length == 2)
                    .MakeGenericMethod(type, propType)
                    .Invoke(null, new object[] { queryable, propertyExpr }) as IOrderedQueryable<T>;

                sorted = true;
            }

            //Linq to entities needs a sort to implement skip
            //Not sure if we care about the queriables that come in sorted? IOrderedQueryable does not seem to be a reliable test
            if (!sorted)
            {
                var firstProp = Expression.Property(paramExpr, propertyMap.First().Value.Property);
                var propType = propertyMap.First().Value.Property.PropertyType;
                var delegateType = Expression.GetFuncType(type, propType);
                var propertyExpr = Expression.Lambda(delegateType, firstProp, paramExpr);

                queryable = typeof(Queryable).GetMethods().Single(
                        method => method.Name == "OrderBy"
                                  && method.IsGenericMethodDefinition
                                  && method.GetGenericArguments().Length == 2
                                  && method.GetParameters().Length == 2)
                    .MakeGenericMethod(type, propType)
                    .Invoke(null, new object[] { queryable, propertyExpr }) as IOrderedQueryable<T>;

            }

        }


        private bool EnumerablFilter(T item)
        {

            var globalFilter = config[DataParserConstants.SearchKey];
            var globalMatch = false;
            var individualMatch = true;
            foreach (var map in propertyMap.Where(m => m.Value.Searchable))
            {
                var propValue = Convert.ToString(map.Value.Property.GetValue(item, null)).ToLower();
                if (!string.IsNullOrWhiteSpace(globalFilter) && propValue.Contains(globalFilter.ToLower()))
                {
                    globalMatch = true;
                }

                if (!string.IsNullOrWhiteSpace(map.Value.Filter) && !propValue.Contains(map.Value.Filter.ToLower()))
                {
                    individualMatch = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(globalFilter))
            {
                return globalMatch && individualMatch;
            }

            return individualMatch;

        }

        /// <summary>
        /// Generate a lamda expression based on a search filter for all mapped columns
        /// </summary>
        private Expression<Func<T, bool>> GenerateEntityFilter()
        {

            var paramExpression = Expression.Parameter(type, "val");

            var filter = config[DataParserConstants.SearchKey];

            ConstantExpression globalFilterConst = null;
            Expression filterExpr = null;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                globalFilterConst = Expression.Constant(filter.ToLower());
            }

            var individualConditions = new List<MethodCallExpression>();
            var modifier = new ModifyParam(paramExpression); //map user supplied converters using a visitor

            foreach (var propMap in propertyMap.Where(m => m.Value.Searchable))
            {
                var prop = propMap.Value.Property;
                var isString = prop.PropertyType == typeof(string);
                var hasCustomExpr = converters.ContainsKey(prop.Name);

                if ((!prop.CanWrite || (convertable.All(t => t != prop.PropertyType) && !isString)) && !hasCustomExpr)
                {
                    continue;
                }

                ConstantExpression individualFilterConst = null;
                if (!string.IsNullOrWhiteSpace(propMap.Value.Filter))
                {
                    individualFilterConst = Expression.Constant(propMap.Value.Filter.ToLower());
                }

                Expression propExp = Expression.Property(paramExpression, prop);

                if (hasCustomExpr)
                {
                    propExp = modifier.Visit(converters[prop.Name]);
                }
                else if (!isString)
                {
                    var toString = prop.PropertyType.GetMethod("ToString", Type.EmptyTypes);

                    propExp = Expression.Call(propExp, toString);

                }

                var toLower = Expression.Call(propExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

                if (globalFilterConst != null)
                {
                    var globalTest = Expression.Call(toLower, typeof(string).GetMethod("Contains"), globalFilterConst);

                    if (filterExpr == null)
                    {
                        filterExpr = globalTest;
                    }
                    else
                    {
                        filterExpr = Expression.Or(filterExpr, globalTest);
                    }
                }

                if (individualFilterConst != null)
                {
                    individualConditions.Add(Expression.Call(toLower, typeof(string).GetMethod("Contains"),
                        individualFilterConst));

                }

            }


            foreach (var condition in individualConditions)
            {
                if (filterExpr == null)
                {
                    filterExpr = condition;
                }
                else
                {
                    filterExpr = Expression.AndAlso(filterExpr, condition);
                }
            }

            // return the expression as a lambda 
            return Expression.Lambda<Func<T, bool>>(filterExpr, paramExpression);

        }

        public class ModifyParam : ExpressionVisitor
        {
            private readonly ParameterExpression replace;

            public ModifyParam(ParameterExpression p)
            {
                replace = p;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return replace;
            }

        }

        private class PropertyMap
        {
            public PropertyInfo Property { get; set; }
            public bool Orderable { get; set; }
            public bool Searchable { get; set; }
            public string Regex { get; set; } //Not yet implemented
            public string Filter { get; set; }
        }
    }

    public class Results<T>
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }
    }
}
