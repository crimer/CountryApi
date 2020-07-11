using CountryApi.Models;
using CountryApi.Repositories;
using System;
using System.Threading.Tasks;

namespace CountryApi.Services
{
    public class MockData : IMockData
    {
        public async Task Init(ApplicationDbContext dbContext)
        {
            dbContext.Countries.Add(new Country
            {
                Id = 1,
                Name = "Япония",
                Capital = "Токио",
                FoundationDate = DateTime.Now,
                CarTraffic = CarTraffic.Left,
                Currency = "Японская иена",
                HDI = 0.915,
                OfficialLanguage = "Японский",
                Territory = 377944,
                GdpTotal = 5390,
                Population = 125900000

            });
            dbContext.Countries.Add(new Country
            {
                Id = 2,
                Name = "Италия",
                Capital = "Рим",
                FoundationDate = DateTime.Now,
                CarTraffic = CarTraffic.Right,
                Currency = "Евро",
                HDI = 0.883,
                OfficialLanguage = "Итальянский",
                Territory = 301340,
                GdpTotal = 2.157,
                Population = 60588366

            });
            

            await dbContext.SaveChangesAsync();
        }
    }
}
