using System;
using System.Collections.Generic;
using System.Linq;

namespace DO.Common.Contract.Enums
{
    public enum AccessRight
    {
        None = 0,

        /// <summary>
        /// Allow to show all resources through out the enterprise. This right is used for Manager role
        /// in some of special case, the manager of branch can look up the resources from head office
        /// </summary> 
        [AccessRightType("System")]
        NoLimitResourceBoundaries = 1,

        //Custody  
        // [AccessRightType(AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        //Custody = 1,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        DongMoTk = 102,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Kyguirutchungkhoan = 103,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        ChuyenKhoanCk = 104,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        TatToanTk = 105,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        PhongToaGiaiToaCk = 106,
        [AccessRightType("Custody")]
        RightInfomation = 107,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        ChuyenNhuongQuyen = 108,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        DkDatMua = 109,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        TraXuatBc = 110,
        [AccessRightType("Custody", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        CustodyReport = 111,

        [AccessRightType("Branch", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Branch = 200,

        [AccessRightType("Department", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Department = 300,

        [AccessRightType("Group", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Group = 400,

        [AccessRightType("User", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        User = 500,
        [AccessRightType("User")]
        GrantAccessRight = 501,

        [AccessRightType("Customer", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Customer = 600,
        [AccessRightType("Customer", AccessType.View, AccessType.Add, AccessType.Override, AccessType.Delete)]
        Asset = 601,
        /// <summary>
        /// Allow to specify the custody account when create new customer
        /// </summary>
        [AccessRightType("Customer")]
        AllowSpecificCustomerAccount = 602,

        [AccessRightType("AdminSetting")]
        AdminSetting = 700
        //AdminProfile = 101,
    }

    public class AccessRightTypeAttribute : Attribute
    {
        public AccessRightTypeAttribute(string group, params AccessType[] accessTypes)
        {
            var rights = new List<AccessType> { AccessType.Deny };
            if (accessTypes.Any())
                rights.AddRange(accessTypes);
            else
                rights.Add(AccessType.Allow);

            Types = rights;
            Group = group;
        }

        public IEnumerable<AccessType> Types { get; }
        public string Group { get; }
    }
}
