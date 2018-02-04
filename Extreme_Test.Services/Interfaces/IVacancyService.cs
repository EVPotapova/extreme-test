using Extreme_Test.Models;
using Extreme_Test.Models.Filters;
using Extreme_Test.Models.Responses;
using System.Threading.Tasks;

namespace Extreme_Test.Services.Interfaces
{
    public interface IVacancyService
    {
        Task SaveNewVacanciesAsync(string apiUrl, bool today = true);
        Task<VacanciesListResponse> GetListOfVacanciesAsync(VacancyFilter filter, ListOptions listOptions);
        Task<VacancyDbModel> GetVacancyAsync(int e1id);
    }
}
