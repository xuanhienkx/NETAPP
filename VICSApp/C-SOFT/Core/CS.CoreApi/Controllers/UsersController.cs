using AutoMapper;
using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Core.Service.Validators;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CS.CoreApi.Controllers
{
    [Route("users")]
    public class UsersController : ApiControllerBase
    {
        private readonly IDataFactory dataFactory;
        private readonly IDataCommandBuilder<Guid, UserModel> commandBuilder;
        private readonly Lazy<IQuery<Guid, UserModel, User>> query;

        public UsersController(ILogger<UsersController> logger,
            IDomainDataHandler domainDataHandler,
            IDataFactory dataFactory,
            IDataCommandBuilder<Guid, UserModel> commandBuilder,
            IStringLocalizer<UsersController> localizer, IMapper mapper)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.dataFactory = dataFactory;
            this.commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));

            query = new Lazy<IQuery<Guid, UserModel, User>>(dataFactory.CreateQuery<Guid, UserModel, User>(
                x => x.Branch,
                x => x.Department,
                x => x.Groups
                ));
        }

        [HttpGet]
        public async Task<IActionResult> GetFilter(string filter)
        {
            return await ResultAsync(() => query.Value.FilterAsync(x => string.IsNullOrEmpty(filter) || x.FullName.Contains(filter)), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ResultAsync(async () =>
            {
                var user = await query.Value.GetAsync(id);
                var groupIds = user.Groups?.Select(x => x.Id).ToList(); 
                //Get right of user
                user.Rights = await DomainDataHandler.SendCommand(new GetPermissionAccessCommand(groupIds));

                //Get group for user is member of
                var groupQuery = dataFactory.CreateQuery<Guid, GroupModel, Group>(x => x.Branch);
                user.Groups = await groupQuery.FilterAsync(x => groupIds.Contains(x.Id));
                return user;
            }, false);
        }

        [HttpPost]
        public async Task<IActionResult> PostNew([FromBody] UserModel user)
        {
            if (!CheckModelStateValidation(user))
                return Result(user);

            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildInsert(user)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(Guid id, [FromBody]UserModel user)
        {
            user.Id = id;
            if (!CheckModelStateValidation(user))
                return Result(user);

            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildUpdate(user)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildDelete(id)));
        }

        [HttpGet("{id}/{isActive}")]
        public async Task<IActionResult> Active(Guid id, bool isActive)
        {
            var command = commandBuilder.BuildCommand(dataContext => new UserUpdateStatusCommand(id, isActive, new UserUpdateStatusValidator(dataContext)));
            return await ResultAsync(() => DomainDataHandler.SendCommand(command));
        }
    }
}
