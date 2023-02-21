using Microsoft.AspNetCore.Mvc;

namespace Demo_K8S.Controllers
{
    [ApiController]
    [Route("api/v1/demo")]
    [Consumes("application/json")]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DemoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string environment = _configuration["Config:Name"];

            return Ok(new { message = "Hello World!", environment = environment });
        }
    }
}
