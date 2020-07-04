using Microsoft.AspNetCore.Mvc;

namespace CountryApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Api Version => 2.0");
        }
    }
}