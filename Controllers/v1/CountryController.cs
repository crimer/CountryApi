using CountryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountryApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;
        /// <summary>
        /// Country controller responsible for GET/POST methods for managing countries
        /// </summary>
        /// <param name="countryRepository"></param>
        public CountryController(ICountryRepository countryRepository, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CountryController>();
            _countryRepository = countryRepository;
        }
        /// <summary>
        /// GET api/country
        /// This GET method returns Mock country data
        /// </summary>
        /// <returns>An array of countries</returns>
        [HttpGet(Name = nameof(GetAllCountries))]
        public async Task<IActionResult> GetAllCountries()
        {
            _logger.LogInformation("Log message in the GET method");
            var countries = _countryRepository.GetAll();
            return Ok(countries);
        }

        [HttpGet("{id:int}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return StatusCode(200, country);
        }
        [HttpPost(Name = nameof(AddCountry))]
        public async Task<IActionResult> AddCountry()
        {
            return Ok();
        }
    }
}