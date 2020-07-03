using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryApi.Repositories
{
    public interface IMockData
    {
        Task Init(ApplicationDbContext dbContext);
    }
}
