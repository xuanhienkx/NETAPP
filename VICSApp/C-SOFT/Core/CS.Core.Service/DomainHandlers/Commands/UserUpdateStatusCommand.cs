using CS.Common.Contract.Models;
using CS.Common.Domain;
using FluentValidation;
using System;

namespace CS.Core.Service.DomainHandlers.Commands
{
    public class UserUpdateStatusCommand : ValidableCommand<UserModel, bool>
    {
        public Guid Id { get; }
        public bool IsActive { get; }

        public UserUpdateStatusCommand(Guid id, bool isActive, IValidator<UserModel> validator)
            : base(validator)
        {
            Id = id;
            IsActive = isActive;
        }
    }
}