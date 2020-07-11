using CountryApi.Models;
using CountryApi.Repositories;
using CountryApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;

        public CountriesController(ICountryRepository countryRepository, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CountriesController>();
            _countryRepository = countryRepository;
        }

        // GET api/country
        [HttpGet(Name = nameof(GetAllCountries))]
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            _logger.LogInformation("Log message in the GET method");
            var countries = await _countryRepository.GetAll();
            return countries;
        }


        // GET api/country/:id
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


        // POST api/country
        [HttpPost(Name = nameof(AddCountry))]
        public async Task<IActionResult> AddCountry([FromBody] CountryVM countryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (countryVM == null)
                    return BadRequest();
                Country country = new Country()
                {
                    Id = 2,
                    Capital = countryVM.Capital,
                    Currency = countryVM.Currency,
                    FoundationDate = countryVM.FoundationDate,
                    Name = countryVM.Name,
                    OfficialLanguage = countryVM.OfficialLanguage,
                    Territory = countryVM.Territory
                };
                await _countryRepository.Add(country);
                await _countryRepository.Save();
                return Ok(country);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, new { error = "Error in saving new Country" });
            }
            
        }
    }
}