using CountryApi.Models;
using CountryApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryApi.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Country country)
        {
            await _context.Countries.AddAsync(country);
        }

        public async Task<int> Count()
        {
            return await _context.Countries.CountAsync();
        }

        public async Task Delete(Country country)
        {
            _context.Countries.Remove(country);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task Update(Country newCountry)
        {
            // nothing
        }
    }
}
