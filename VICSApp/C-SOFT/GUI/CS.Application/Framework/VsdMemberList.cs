using CS.Common.Contract.VsdModels;
using CS.UI.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CS.Application.Framework
{
    public class VsdMemberList
    {
        public static VsdMemberList Current { get; private set; }

        public static void UseConfig(string configPath, Assembly assembly)
        {
            Current = new VsdMemberList(configPath, assembly);
        }

        private readonly string configPath;
        private readonly Assembly assembly;
        private IList<VsdMember> items;
        public IList<VsdMember> Items => items ?? (items = assembly.LoadFromSource<IList<VsdMember>>(configPath));

        public IList<VsdMember> ItemsFilter(string filter = null, string bicCode = null)
        {
            IList<VsdMember> filterList = Items.Where(x => string.IsNullOrEmpty(filter) || x.Code.ToLower().Contains(filter.ToLower()) && (string.IsNullOrEmpty(bicCode) || x.BicCode.Equals(bicCode))).ToList();
            return filterList;
        }

        public VsdMember GetMember(string code)
        {
            return ItemsFilter(null,code).FirstOrDefault(); 
        }
        public VsdMember GetMemberCode(string code)
        {
            return ItemsFilter(code).FirstOrDefault();
        }
        private VsdMemberList(string configPath, Assembly assembly)
        {
            this.configPath = configPath;
            this.assembly = assembly;
        }
    }
}