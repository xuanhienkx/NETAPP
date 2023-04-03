using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using SBSCore.Common;
using SBSCore.Security;

namespace SBSCore.DomainHelper
{
   public static class AgencyHelper
   {
      public static List<UnitTrade> GetUnitTradeCode(UserLite user)
      {
         var context = DBUtil.CreateContext();
         var units = context.UnitTradeCodes.Where(x => x.Status == 'O' && x.IsShow);

         if (user.BranchCode != "200")
            units = units.Where(x => x.BranchCode == user.BranchCode && !Util.AgencyAsBranch.Contains(x.TradeCode));
         if (user.IsAgencyUser)
            units = units.Where(x => x.TradeCode == user.TradeCode);

         return
            units.OrderBy(x => x.UnitType)
               .ToList()
               .Select(x => new UnitTrade()
                            {
                               BranchCode = x.BranchCode,
                               TradeCode = x.TradeCode,
                               Name = x.UnitName,
                               ParentTradeCode = x.ParentUnit,
                               PostType = x.PostType,
                               Type = x.UnitType == 3 && Util.AgencyAsBranch.Contains(x.TradeCode) ? 1 : x.UnitType
                            }).ToList();
      }
   }
}
