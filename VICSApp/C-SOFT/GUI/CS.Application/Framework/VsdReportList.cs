using CS.UI.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CS.Application.Framework
{
    public class VsdReportModel
    {
        public string ReportCode { get; set; }
        public string ReportName { get; set; }
        public string ParamsModelType { get; set; }
    }

    public class VsdReportList
    {
        public static VsdReportList Current { get; private set; }

        public static void UseConfig(string configPath, Assembly assembly)
        {
            Current = new VsdReportList(configPath, assembly);
        }
        private readonly string configPath;
        private readonly Assembly assembly;
        private IList<VsdReportModel> items;
        public IList<VsdReportModel> Items => items ?? (items = assembly.LoadFromSource<IList<VsdReportModel>>(configPath));
        public IList<VsdReportModel> ItemsFilter(string filter)
        {
            IList<VsdReportModel> filterList = Items.Where(x => string.IsNullOrEmpty(filter) || x.ReportCode.ToLower().Contains(filter.ToLower())).ToList();
            return filterList;
        }

        public VsdReportList(string configPath, Assembly assembly)
        {
            this.configPath = configPath;
            this.assembly = assembly;

        }
    }
}