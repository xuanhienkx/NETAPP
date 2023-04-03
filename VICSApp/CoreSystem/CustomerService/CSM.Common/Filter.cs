using System.Collections.Generic;

namespace CSM.Common
{
    public class Filter
    {
        public IEnumerable<Criterion> Criteria { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public SortField SortField { get; set; }
    }
    public class SortField
    {
        public SortField(string fieldName, bool isAsc)
        {
            FieldName = fieldName;
            IsAscending = isAsc;
        }
        public string FieldName { get; set; }
        public bool IsAscending { get; set; }
    }
    public class Criterion
    {
        public CriterionType Type { get; set; }
        public Operator Operator { get; set; }
        public string Value { get; set; }
        public string Field { get; set; }
    }
    
    public enum Operator
    {
        Equals,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        DifferenceOf,
        Contains,
        StartWith,
        EndWith
    }

    public enum CriterionType
    {
        Not,
        And,
        AndAlso
    }
}
