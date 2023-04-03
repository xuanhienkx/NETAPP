using AutoMapper;
using CS.Common;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using AccessRight = CS.Common.Contract.Enums.AccessRight;

namespace CS.CoreApi.Controllers
{
    [Route("branches")]
    public class BranchesController : ApiControllerBase
    {
        private readonly IDomainService<long, BranchModel, Branch> service;
        public BranchesController(ILogger<BranchesController> logger,
            IDomainDataHandler domainDataHandler,
            IDomainService<long, BranchModel, Branch> service,
            IStringLocalizer<BranchesController> localizer,
            IMapper mapper)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Logger.LogDebug("GET");
            return await ResultAsync(async () =>
            {
                if (User.IsInRole(UserRoleType.Admin))
                    return await service.Query.GetAllAsync();

                var loginUser = DomainDataHandler.GetUserLogin();
                if (loginUser.Has(AccessRight.NoLimitResourceBoundaries))
                    return await service.Query.GetAllAsync();

                return await service.Query.FilterAsync(x => x.Id == loginUser.Branch.Id);
            }, false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(long id)
        {
            return await ResultAsync(async () => await service.Query.GetAsync(id), false);
        }

        [HttpPost]
        public async Task<IActionResult> PostInsert([FromBody]BranchModel branch)
        {
            if (!CheckModelStateValidation(branch))
                return Result(branch);

            return await ResultAsync(() => service.Insert(branch));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(long id, [FromBody]BranchModel branch)
        {
            branch.Id = id;
            if (!CheckModelStateValidation(branch))
                return Result(branch);

            return await ResultAsync(() => service.Update(branch));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ResultAsync(async () => await service.Delete(id));
        }
    }
}
