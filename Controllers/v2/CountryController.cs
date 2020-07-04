using Microsoft.AspNetCore.Mvc;

namespace CountryApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    /// <summary>
    /// 2 api version test controller
    /// </summary>
    /// <param name="countryRepository"></param>
    public class CountryController : Controller
    {
        /// <summary>
        /// This GET method returns "Api Version => 2.0" text
        /// </summary>
        /// <returns>An array of countries</returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Api Version => 2.0");
        }
    }
}