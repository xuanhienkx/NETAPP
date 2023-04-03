using System;
using System.Linq;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using FluentValidation;

namespace CS.Core.Service.Validators
{
    public class GroupDeleteValidator : GroupValidator
    {  
        protected GroupDeleteValidator(ICSoftDataContext context) : base(context)
        {
            ValidateId();
        }
    }
    public class GroupInsertValidator :  GroupValidator
    { 

        public GroupInsertValidator(ICSoftDataContext context) : base(context)
        {
            CommonValidate();
            ValidateName();
        } 
    }
    public class GroupUpdateValidator : GroupValidator
    {
        public GroupUpdateValidator(ICSoftDataContext context) : base(context)
        {
            ValidateId();
            CommonValidate();
            ValidateName();
        }
    }
    public class GroupAccessRightValidator : GroupValidator
    {
        public GroupAccessRightValidator(ICSoftDataContext context) : base(context)
        {
            ValidateId(); 
        }
    }
}