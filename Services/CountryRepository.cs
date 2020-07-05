using CountryApi.Models;
using CountryApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountryApi.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Country country)
        {
            _context.Country.Add(country);
        }

        public int Count()
        {
            return _context.Country.Count();
        }

        public void Delete(int id)
        {
            Country country = GetCountryById(id);
            _context.Country.Remove(country);
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Country.Include(c => c.Population).Include(c => c.GDP);
        }

        public Country GetCountryById(int id)
        {
            return _context.Country
                .Include(c => c.Population).Include(c => c.GDP)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Country Update(int id, Country newCountry)
        {
            throw new NotImplementedException();
        }
    }
}
