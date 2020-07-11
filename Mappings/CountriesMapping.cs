using AutoMapper;
using CountryApi.Models;
using CountryApi.ViewModels;
using CountryApi.ViewModels.Country;

namespace CountryApi.Mappings
{
    public class CountriesMapping : Profile
    {
        public CountriesMapping()
        {
            // Sourse -> Target
            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();
            CreateMap<CountryUpdateVM, Country>();
        }
    }
}
