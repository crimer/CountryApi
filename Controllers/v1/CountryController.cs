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

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

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
            return StatusCode(200, country);
        }
    }
}