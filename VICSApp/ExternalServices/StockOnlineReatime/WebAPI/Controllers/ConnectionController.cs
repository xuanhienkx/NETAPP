using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{ 
    [Route("Connection")]
    public class ConnectionController : Controller
    {
        private readonly IConfigurationRoot config;

        public ConnectionController(IConfigurationRoot config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }
        [HttpGet("{year}")]
        public string GetToken( int year)
        {
            var apiToken = SecurityHelper.GenerateServiceToken(config.GetSection("security"), year);

            return apiToken;
        }
    }
}