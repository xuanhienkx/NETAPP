using System.Collections.Generic;

namespace CSM.Common
{
    public class ResultList<T>
    {
        public IList<T> List { get; set; }
        public Filter Filter { get; set; }
        public int TotalCount { get; set; }
    }
}
