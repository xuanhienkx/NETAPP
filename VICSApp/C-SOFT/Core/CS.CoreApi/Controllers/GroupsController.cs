using AutoMapper;
using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Domain;

namespace CS.CoreApi.Controllers
{
    [Route("groups")]
    public class GroupsController : ApiControllerBase
    {
        private readonly IDataCommandBuilder<Guid, GroupModel> commandBuilder;
        private readonly Lazy<IQuery<Guid, GroupModel, Group>> query;
        public GroupsController(IDomainDataHandler domainDataHandler,
            ILogger<ApiControllerBase> logger,
            IStringLocalizer<GroupsController> localizer,
            IMapper mapper,
            IDataFactory dataFactory,
            IDataCommandBuilder<Guid, GroupModel> commandBuilder)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            if (dataFactory == null) throw new ArgumentNullException(nameof(dataFactory));
            this.commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
            query = new Lazy<IQuery<Guid, GroupModel, Group>>(dataFactory.CreateQuery<Guid, GroupModel, Group>(
                 x => x.Branch,
                 x => x.Parent
             ));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Logger.LogDebug("GET");
            return await ResultAsync(async () => await query.Value.GetAllAsync(), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            return await ResultAsync(async () => await query.Value.GetAsync(id), false);
        }

        [HttpPost]
        public async Task<IActionResult> PostInsert([FromBody]GroupModel model)
        {
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildInsert(model)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(Guid id, [FromBody]GroupModel model)
        {
            model.Id = id;
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildUpdate(model)));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Result(async () =>
            {
                var result = await DomainDataHandler.SendCommand(commandBuilder.BuildDelete(id));
                if (!result)
                    NotifyError(localizer => localizer["GroupIsInUsed_CannotDelete"]);

                return result;
            });
        }

        [HttpGet("{id}/rights")]
        public async Task<IActionResult> GetRights(Guid id)
        {
            return await ResultAsync(() => DomainDataHandler.SendCommand(new GetPermissionAccessCommand(new List<Guid> { id })), false);
        }

        [HttpPut("{id}/rights")]
        public async Task<IActionResult> PutUpdateRights(Guid id, [FromBody] IList<PermissionAccess> permissions)
        {
            if (permissions == null)
            {
                NotifyError(Localizer["DataContractIsNull"]);
                return Result(false);
            }

            return await ResultAsync(() => DomainDataHandler.SendCommand(new SetCommand<GroupModel, Guid, IList<PermissionAccess>>(id, permissions)));
        }

        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetMembers(Guid id)
        {
            return await ResultAsync(() => DomainDataHandler.SendCommand(new GetCommand<GroupModel, Guid, IList<GroupMemberModel>>(id)), false);
        }
    }
}