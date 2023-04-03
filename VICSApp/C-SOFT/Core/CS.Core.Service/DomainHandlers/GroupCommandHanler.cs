using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Core.Service.Base;
using CS.Core.Service.DomainHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Core.Service.DomainHandlers
{

    public class GroupCommandHanler : ActionCommandHandler<GroupModel, Guid>,
                                      IRequestHandler<SetCommand<GroupModel, Guid, IList<PermissionAccess>>, bool>,
                                      IRequestHandler<GetPermissionAccessCommand, IList<PermissionAccess>>,
                                      IRequestHandler<GetCommand<GroupModel, Guid, IList<GroupMemberModel>>, IList<GroupMemberModel>>

    {
        private readonly IGroupRepository repository;
        public GroupCommandHanler(IValidationService validationService, ICacheService cacheService, IGroupRepository repository) : 
            base(validationService, cacheService)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override bool UseCache => true;
        protected override async Task<bool> Delete(Guid messageId)
        {
            return await repository.Delete(messageId, false);
        }

        protected override async Task<GroupModel> Update(GroupModel model)
        {
            return await repository.Update(model);
        }

        protected override async Task<GroupModel> Insert(GroupModel model)
        {
            return await repository.Insert(model);
        }

        public async Task<bool> Handle(SetCommand<GroupModel, Guid, IList<PermissionAccess>> request, CancellationToken cancellationToken)
        {
            if (!ValidationService.Validate(request))
                return false;
            if (!request.Updated.Any())
                return false;

            return await repository.SetAccessRights(request.Id, request.Updated);
        }

        /// <summary>
        /// Get access rights
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IList<PermissionAccess>> Handle(GetPermissionAccessCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetAccessRights(request.GroupIds);
        }

        /// <summary>
        /// Get group members
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IList<GroupMemberModel>> Handle(GetCommand<GroupModel, Guid, IList<GroupMemberModel>> request, CancellationToken cancellationToken)
        {
            return await repository.GetMembers(request.Id);
        }
    }
}