using CountryApi.Models;
using System.Collections.Generic;

namespace CountryApi.Repositories
{
    public interface ICountryRepository
    {
        Country GetCountryById(int id);
        void Add(Country country);
        void Delete(int id);
        Country Update(int id, Country newCountry);
        IEnumerable<Country> GetAll();
        int Count();
        bool Save();
    }
}
