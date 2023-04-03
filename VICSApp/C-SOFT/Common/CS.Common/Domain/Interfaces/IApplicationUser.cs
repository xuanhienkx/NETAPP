using System;

namespace CS.Common.Domain.Interfaces
{
    public interface IApplicationUser
    {
        Guid Id { get; }
        //
        // Summary:
        //     Gets or sets a flag indicating if the user could be locked out.
        bool LockoutEnabled { get; }
        //
        // Summary:
        //     Gets or sets the number of failed login attempts for the current user.
       int AccessFailedCount { get; }
    }
}
