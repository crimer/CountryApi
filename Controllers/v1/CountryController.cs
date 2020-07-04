using CountryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CountryApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        /// <summary>
        /// Country controller responsible for GET/POST methods for managing countries
        /// </summary>
        /// <param name="countryRepository"></param>
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        /// <summary>
        /// This GET method returns Mock country data
        /// </summary>
        /// <returns>An array of countries</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {

            var countries = _countryRepository.GetAll();
            System.Diagnostics.Debug.WriteLine(countries);
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return StatusCode(200, country);
        }
    }
}