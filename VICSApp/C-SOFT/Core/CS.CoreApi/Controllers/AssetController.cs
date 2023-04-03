using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CS.CoreApi.Controllers
{
    [Route("assets")]
    public class AssetController : ApiControllerBase
    {
        private readonly IDomainService<long, AssetModel, Asset> service;

        public AssetController(IDomainDataHandler domainDataHandler, ILogger<AssetController> logger, IDomainService<long, AssetModel, Asset> service, IStringLocalizer<AssetController> localizer, IMapper mapper)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new System.ArgumentNullException(nameof(service));
        }
        // GET api/assets
        [HttpGet]
        public async Task<IActionResult> Get(string code, AssetType type = AssetType.Stock)
        {
            return await ResultAsync(() => service.Query.FilterAsync(x => (string.IsNullOrEmpty(code) || x.Code.Contains(code)) && x.Type == type), false);
        }

        // GET api/assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ResultAsync(() => service.Query.GetAsync(id), false);
        }

        // POST api/assets
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]AssetModel asset)
        {
            if (!CheckModelStateValidation(asset))
                return Result(asset);

            return await ResultAsync(() => service.Insert(asset));
        }

        // PUT api/assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AssetModel asset)
        {
            asset.Id = id;
            if (!CheckModelStateValidation(asset))
                return Result(asset);

            return await ResultAsync(() => service.Update(asset));
        }

        // DELETE api/assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await ResultAsync(() => service.Delete(id));
        }
    }
}