using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace AksApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> logger;

        public SampleController(ILogger<SampleController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello, World!";
        }
    }
}