using Extreme_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Test.Data
{
    public interface IVacanciesDataHelper
    {
        Task<ICollection<VacancyDbModel>> GetListAsync(IQueryable<VacancyDbModel> query);

        Task<VacancyDbModel> GetAsync(int e1id);

        IQueryable<VacancyDbModel> GetQueryable();
        


        Task AddAsync(VacancyDbModel vacancy);
        Task AddListAsync(ICollection<VacancyDbModel> vacancy);
        Task UpdateAsync(VacancyDbModel vacancy);

        bool HasAny(int e1Id);
    }

}
