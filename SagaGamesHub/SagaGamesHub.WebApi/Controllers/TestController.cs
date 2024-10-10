using Microsoft.AspNetCore.Mvc;

namespace SagaGamesHub.WebApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Test Controller works";
    }
}
