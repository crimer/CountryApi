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
            dbContext.Country.Add(new Country
            {
                Id = 1,
                Name = "Япония",
                Capital = "Токио",
                FoundationDate = DateTime.Now,
                CarTraffic = CarTraffic.left,
                Currency = "Японская иена",
                HDI = 0.915,
                OfficialLanguage = "Японский",
                Territory = 377944,
                GDP = new GDP() { Id = 1, Total = 5390, PerPerson = 42325 },
                Population = new Population() { Id = 1, Size = 125900000, Value = 333.1 }

            });
            

            await dbContext.SaveChangesAsync();
        }
    }
}
