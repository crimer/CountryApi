using CountryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Country { get; set; }
    }
}
