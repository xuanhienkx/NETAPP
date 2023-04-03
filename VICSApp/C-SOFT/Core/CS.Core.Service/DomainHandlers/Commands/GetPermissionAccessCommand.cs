using System;
using System.Collections.Generic;
using CS.Common.Contract.Models;
using MediatR;

namespace CS.Core.Service.DomainHandlers.Commands
{
    public class GetPermissionAccessCommand : IRequest<IList<PermissionAccess>>
    {
        public IList<Guid> GroupIds { get; }

        public GetPermissionAccessCommand(IList<Guid> groupIds)
        {
            GroupIds = groupIds;
        }
    }
}