using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SMS.Common
{
    public delegate T ObjectActivator<T>(params object[] args);
    public static class ExtensionMethods
    {
        public static ObjectActivator<T> GetActivator<T>(ConstructorInfo constructorInfo)
        {
            var paramsInfo = constructorInfo.GetParameters();

            //create a single param of type object[]
            var param =
                Expression.Parameter(typeof(object[]), "args");

            var argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(constructorInfo, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda =
                Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            var compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }

        public static string ReplaceText(this Dictionary<string, object> entity, string sourceText)
        {
            if (sourceText == null) return null;

            var e = entity;

            var result = "";
            var rest = sourceText;

            // parse loops
            var beginLoopLen1 = "<%BeginLoop(".Length;
            var beginLoopLen2 = ")%>".Length;
            var endLoopLen1 = "<%EndLoop%>".Length;
            var beginLoopIndex = sourceText.IndexOf("<%BeginLoop(", StringComparison.Ordinal);
            var endLoopIndex = sourceText.LastIndexOf("<%EndLoop%>", StringComparison.Ordinal);
            if (beginLoopIndex != -1 && endLoopIndex != -1)
            {
                var tmpStr = sourceText.Substring(beginLoopIndex + beginLoopLen1, endLoopIndex - beginLoopIndex - beginLoopLen1);
                var beginTagEndIndex = tmpStr.IndexOf(")%>", StringComparison.Ordinal);
                var collectionName = tmpStr.Substring(0, beginTagEndIndex);
                tmpStr = tmpStr.Substring(beginTagEndIndex + beginLoopLen2);
                var test = GetValueFromToken(e, collectionName);
                var collection = (IList)test;

                try
                {
                    var resultingStr = collection.Cast<object>()
                        .Aggregate(string.Empty,
                            (current, item) =>
                                current +
                                item.GetType()
                                    .GetProperties()
                                    .ToDictionary(x => x.Name, x => x.GetValue(item, null))
                                    .ReplaceText(tmpStr));
                   
                    rest = sourceText.Substring(0, beginLoopIndex) + resultingStr + sourceText.Substring(endLoopIndex + endLoopLen1);
                }
                catch (Exception ex)
                { 
                    throw ex;
                }
            }

            // parse properties
            while (true)
            {
                var startIndex = rest.IndexOf("<%=", StringComparison.Ordinal);
                var startIndex2 = startIndex + 3;
                var endIndex = rest.IndexOf("%>", StringComparison.Ordinal);
                var endIndex2 = endIndex + 2;
                if ((startIndex >= 0) && (endIndex >= 0) && (endIndex > startIndex))
                {
                    result += rest.Substring(0, startIndex);
                    var token = rest.Substring(startIndex2, endIndex - startIndex2);

                    // parse format
                    var formatStringStart = token.IndexOf('{');
                    var formatStringEnd = token.IndexOf('}');
                    var formatString = "";
                    if ((formatStringStart != -1) && (formatStringEnd != -1))
                    {
                        formatString = token.Substring(formatStringStart, formatStringEnd - formatStringStart + 1);
                        token = token.Substring(0, formatStringStart);
                    }

                    object val = GetValueFromToken(e, token);

                    if (val != null)
                    {
                        if (!string.IsNullOrEmpty(formatString))
                        {
                            result += string.Format(CultureInfo.CurrentUICulture, formatString, val);
                        }
                        else
                        {
                            if (val.GetType() == typeof(Decimal))
                            {
                                result += ((decimal)val).ToString("0.00", CultureInfo.CurrentCulture);
                            }
                            else
                            {
                                result += val.ToString();
                            }
                        }
                    }
                    rest = rest.Substring(endIndex2);
                }
                else
                {
                    result += rest;
                    break;
                }
            }

            return result;
        }
        public static string XmlReplaceText(this Dictionary<string, object> entity, string sourceText)
        {
            if (sourceText == null) return null;
            var e = entity;

            var result = "";
            var rest = sourceText;

            // parse properties
            while (true)
            {
                var startIndex = rest.IndexOf("$%", StringComparison.Ordinal);
                var startIndex2 = startIndex + 2;
                var endIndex = rest.IndexOf("%$", StringComparison.Ordinal);
                var endIndex2 = endIndex + 2;
                if ((startIndex >= 0) && (endIndex >= 0) && (endIndex > startIndex))
                {
                    result += rest.Substring(0, startIndex);
                    var token = rest.Substring(startIndex2, endIndex - startIndex2);

                    //// parse format
                    var formatStringStart = token.IndexOf('{');
                    var formatStringEnd = token.IndexOf('}');
                    var formatString = "";
                    if ((formatStringStart != -1) && (formatStringEnd != -1))
                    {
                        formatString = token.Substring(formatStringStart, formatStringEnd - formatStringStart + 1);
                        token = token.Substring(0, formatStringStart);
                    }

                    object val = GetValueFromToken(e, token);

                    if (val != null)
                    {
                        if (!string.IsNullOrEmpty(formatString))
                        {
                            result += string.Format(CultureInfo.CurrentUICulture, formatString, val);
                        }
                        else
                        {
                            if (val.GetType() == typeof(Decimal))
                            {
                                result += ((decimal)val).ToString("##,###.00", CultureInfo.CurrentCulture);
                            }
                            else if (val.GetType() == typeof(int))
                            {
                                result += ((decimal)val).ToString("##,###", CultureInfo.CurrentCulture);
                            }
                            else
                            {
                                result += val.ToString();
                            }
                        }
                    }
                    rest = rest.Substring(endIndex2);
                }
                else
                {
                    result += rest;
                    break;
                }
            }

            return result;
        }

        public static object GetValueFromToken(this Dictionary<string, object> properties, string token)
        {
            return !properties.ContainsKey(token) ? null : properties[token];
        }
    }
}
