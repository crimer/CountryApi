using CountryApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryApi.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryById(int id);
        Task Add(Country country);
        Task Delete(Country country);
        Task Update(Country newCountry);
        Task<IEnumerable<Country>> GetAll();
        Task<int> Count();
        Task<bool> Save();
    }
}
