using System;
using System.Collections.Generic;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;

namespace CS.Common.Contract
{
    public interface IPersonModel : IReversionResource<Guid>
    {
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string AccountLogin { get; set; }
        string FullName { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        UserModel CreatedBy { get; set; }
        UserModel ModifiedBy { get; set; }
        BranchModel Branch { get; set; }
    }

    public interface IUserLogin
    {
        BranchModel Branch { get; }
        string LanguageCode { get; }
        UserType UserType { get; }
        IList<PermissionAccess> Rights { get; }
        Guid Id { get; }
        string AccountLogin { get; }
        string Email { get; }
        string PhoneNumber { get; }
        bool IsActive { get; }
    }
}
