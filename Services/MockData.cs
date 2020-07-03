using CountryApi.Models;
using CountryApi.Repositories;
using System.Threading.Tasks;

namespace CountryApi.Services
{
    public class MockData : IMockData
    {
        public async Task Init(ApplicationDbContext dbContext)
        {
            dbContext.Country.Add(new Country { });
            dbContext.Country.Add(new Country { });
            dbContext.Country.Add(new Country { });
            dbContext.Country.Add(new Country { });

            await dbContext.SaveChangesAsync();
        }
    }
}
