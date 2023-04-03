using DO.Common.Contract.Enums;
using DO.Common.Contract.Models;
using System;
using System.Collections.Generic;

namespace DO.Common.Contract
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
    }

    public interface IUserLogin
    {
        string LanguageCode { get; }
        UserType UserType { get; }
        Guid Id { get; }
        string AccountLogin { get; }
        string Email { get; }
        string PhoneNumber { get; }
        bool IsActive { get; }
    }

}