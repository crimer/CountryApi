using AutoMapper;
using CountryApi.Models;
using CountryApi.Repositories;
using CountryApi.ViewModels;
using CountryApi.ViewModels.Country;
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
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CountriesController>();
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        // GET api/countries
        [HttpGet(Name = nameof(GetAllCountries))]
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            _logger.LogInformation("Log message in the GET method");
            var countries = await _countryRepository.GetAll();
            return countries;
        }

        // GET api/countries/:id
        [HttpGet("{id:int}", Name = nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CountryVM>(country.Result));
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
                var countryModel = _mapper.Map<Country>(countryVM);
                await _countryRepository.Add(countryModel);
                await _countryRepository.Save();
                return CreatedAtRoute(nameof(AddCountry), countryModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, new { error = "Error in saving new Country" });
            }

        }

        // PUT api/countries/:id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryUpdateVM updateVM)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            _mapper.Map(updateVM, country);
            await _countryRepository.Update(country);
            await _countryRepository.Save();
            return Ok(country);
        }

        // DELETE api/countries/:id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            await _countryRepository.Delete(country);
            await _countryRepository.Save();
            return Ok();
        }
    }
}