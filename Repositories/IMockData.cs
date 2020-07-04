using System.Threading.Tasks;

namespace CountryApi.Repositories
{
    public interface IMockData
    {
        Task Init(ApplicationDbContext dbContext);
    }
}
