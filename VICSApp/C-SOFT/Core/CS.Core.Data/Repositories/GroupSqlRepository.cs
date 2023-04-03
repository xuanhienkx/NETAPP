using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS.Domain.Data.Repositories
{
    public class GroupSqlRepository : RepositoryBase<Guid, GroupModel, Group>, IGroupRepository
    {
        private readonly IApplicationUserAccessor applicationUserAccessor;

        public GroupSqlRepository(CSoftDataContext dataContext,
                                IMapper mapper,
                                IApplicationUserAccessor applicationUserAccessor)
                                : base(dataContext, mapper)
        {
            this.applicationUserAccessor = applicationUserAccessor ?? throw new ArgumentNullException(nameof(applicationUserAccessor));
        }

        protected override Group StartPreparingForInsert(GroupModel model)
        {
            return new Group() { Id = Guid.NewGuid() };
        }

        protected override Group StartPreparingForUpdate(GroupModel model)
        {
            //Remove before add
            var existedUserGroups = DataContext.Set<UserGroup>().Where(x => x.GroupId == model.Id).ToList();
            DataContext.Set<UserGroup>().RemoveRange(existedUserGroups); 
            DataContext.SaveChanges();

            var entity = DataContext.Set<Group>().FirstOrDefault(x => x.Id == model.Id);
            if (model.Members.Any() && entity != null)
            {
                var memberContext = DataContext.Set<UserGroup>(); 
                //add member to group
                var dbUserMember = model.Members
                                        .Select(member => new UserGroup()
                                        {
                                            GroupId = entity.Id,
                                            UserId = member.Id
                                        }).ToList();
                memberContext.AddRange(dbUserMember);
            }
            return entity;
        }

        protected override bool ValidateDelete(Group deleted)
        {
            var isInUsed = DataContext.Set<Group>().Any(x => x.ParentId == deleted.Id);
            return !isInUsed && DataContext.Set<UserGroup>().Any(x => x.GroupId == deleted.Id);
        }

        protected override void RecoveredModel(Group db, GroupModel resource)
        {

        }

        protected override void CleanupBeforeDelete(Guid id)
        {
            var permissions = DataContext.Set<Permission>().Where(x => x.GroupId.Equals(id));
            DataContext.Set<Permission>().RemoveRange(permissions);
        }

        public async Task<IList<PermissionAccess>> GetAccessRights(IList<Guid> ids)
        {
            var permissions = await DataContext.Set<Permission>()
                .Where(x => ids.Contains(x.GroupId))
                .GroupBy(x => x.Name)
                .Select(g => new PermissionAccess(g.Key, g.Max(x => x.Type)))
                .ToListAsync();

            return Mapper.Map<IList<PermissionAccess>>(permissions);

        }

        public async Task<bool> SetAccessRights(Guid id, IList<PermissionAccess> permissions)
        {
            //Remove Existed Permission
            var exitedPermissions = DataContext.Set<Permission>()
                                               .Where(x => x.GroupId.Equals(id));
            DataContext.Set<Permission>().RemoveRange(exitedPermissions);

            //Add new Permission
            var dbPermissionNew = permissions.Select(item => new Permission()
            {
                GroupId = id,
                CreatedDate = DateTime.Now,
                Name = item.Name,
                Type = item.Type,
                CreatedById = applicationUserAccessor.GetUserId()
            }).ToList();

            await DataContext.Set<Permission>().AddRangeAsync(dbPermissionNew);
            await DataContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<GroupMemberModel>> GetMembers(Guid id)
        {
            var result = new List<GroupMemberModel>();

            // group members
            var groups = await DataContext.Set<Group>()
                .Where(x => x.ParentId == id)
                .OrderBy(x => x.Name)
                .ToListAsync();
            if (groups.Any())
                result.AddRange(groups.Select(g => Mapper.Map<GroupMemberModel>(g)));

            // users members
            var userIds = DataContext.Set<UserGroup>().Where(x => x.GroupId == id).Select(x => x.UserId);
            var users = await DataContext.Set<User>()
                .Where(x => userIds.Contains(x.Id))
                .OrderBy(x => x.FullName)
                .ToListAsync();
            if (users.Any())
                result.AddRange(users.Select(u => Mapper.Map<GroupMemberModel>(u)));

            return result;
        }
    }
}