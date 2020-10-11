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
            logger.LogInformation("Hello World");
            return "Hello, World!";
        }
    }
}