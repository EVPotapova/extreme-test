using Extreme_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extreme_Test.Data
{
    public class VacanciesDataHelper : IVacanciesDataHelper
    {
        ApplicationContext dbContext;

        public VacanciesDataHelper(ApplicationContext context)
        {
            dbContext = context;
        }
        

        public async Task<VacancyDbModel> GetAsync(int e1id)
        {
            return await dbContext.Vacancies.FirstOrDefaultAsync(x => x.E1Id == e1id);
        }

        public async Task AddAsync(VacancyDbModel vacancy)
        {
            await dbContext.Vacancies.AddAsync(vacancy);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(VacancyDbModel vacancy)
        {
            dbContext.Update(vacancy);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddListAsync(ICollection<VacancyDbModel> vacancies)
        {
            await dbContext.Vacancies.AddRangeAsync(vacancies);
            await dbContext.SaveChangesAsync();
        }

        public bool HasAny(int e1Id)
        {
            return dbContext.Vacancies.Any(v => v.E1Id == e1Id);
        }

        public async Task<ICollection<VacancyDbModel>> GetListAsync(IQueryable<VacancyDbModel> query)
        {
            return await query.ToListAsync();
        }

        public IQueryable<VacancyDbModel> GetQueryable()
        {
            return dbContext.Vacancies;
        }
    }
}
