using System.Collections.Generic;
using System.Threading.Tasks;
using Extreme_Test.Models;
using Extreme_Test.Services.Interfaces;
using System;
using Newtonsoft.Json;
using System.Linq;
using Extreme_Test.Data;
using Extreme_Test.Models.Filters;
using Extreme_Test.Models.Responses;
using System.Text.RegularExpressions;

namespace Extreme_Test.Services.Services
{
    public class VacancyService : IVacancyService
    {
        public readonly IVacanciesDataHelper DataHelper;
        private readonly IWebApiClient WebApiClient;
        public VacancyService(IVacanciesDataHelper dataHelper, IWebApiClient webApiClient)
        {
            DataHelper = dataHelper;
            WebApiClient = webApiClient;
        }


        public async Task SaveNewVacanciesAsync(string apiUrl, bool today = true)//TODO: filter
        {
            if (today)
            {
                apiUrl += "&period=month";//TODO: unhardcode
            }
            List<VacancyDbModel> vacancies = null;


            var response = await WebApiClient.GetAsync<ApiResponse>(apiUrl);

            if (response != null && response.Vacancies != null && response.Vacancies.Any())
            {
                vacancies = response.Vacancies.Select(v => new VacancyDbModel
                {
                    E1Id = v.id,
                    Header = v.header,
                    SalaryMax = v.salary_max_rub,
                    SalaryMin = v.salary_min_rub,
                    Experience = EnumHelper<ExperienceEnum>.GetValueFromName(v.experience_length?.title),
                    WorkingType = EnumHelper<WorkingTypeEnum>.GetValueFromName(v.working_type?.title),
                    Schedule = EnumHelper<ScheduleEnum>.GetValueFromName(v.schedule?.title),
                    Desc = Regex.Replace(v.description, "<.*?>", " "),
                    LinkToE1 = $"https://ekb.zarplata.ru/vacancy/card/{v.id}"//TODO: to config
                }).ToList();//TODO: Use Automapper

                foreach (var vacancy in vacancies)
                {
                    if (!DataHelper.HasAny(vacancy.E1Id))
                    {
                        await DataHelper.AddAsync(vacancy);
                    }
                }
            }
        }


        public async Task<VacancyDbModel> GetVacancyAsync(int e1id)
        {
            return await DataHelper.GetAsync(e1id);
        }

        public async Task<VacanciesListResponse> GetListOfVacanciesAsync(VacancyFilter filter, ListOptions options)
        {
            if (filter == null)
            {
                filter = new VacancyFilter();
            }
            if (options == null)
            {
                options = new ListOptions();
            }

            IQueryable<VacancyDbModel> query = DataHelper.GetQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Header))
            {
                var head = filter.Header.Trim();
                query = query.Where(u => u.Header.Contains(head));
            }

            if (filter.SalaryMin != null)
            {
                query = query.Where(u => u.SalaryMin >= filter.SalaryMin);
            }

            if (filter.SalaryMax != null)
            {
                query = query.Where(u => u.SalaryMax <= filter.SalaryMax);
            }

            if(filter.Experience!=null && filter.Experience.Any())
            {

                query = query.Where(u => filter.Experience.Contains(u.Experience));
            }


            //Get count of all results
            var count = query.Count();

            query = options.ApplySort(query, "-E1Id");
            query = options.ApplyPaging(query);

            var dbVacancies = await DataHelper.GetListAsync(query);

            var response = new VacanciesListResponse
            {
                Items = dbVacancies.Select(v => new VacancyGetModel
                {
                    E1Id = v.E1Id,
                    Header = v.Header,
                    Desc = v.Desc,
                    LinkToE1 = v.LinkToE1,
                    Info = $"Опыт: {EnumHelper<ExperienceEnum>.GetDisplayValue(v.Experience)}, {EnumHelper<WorkingTypeEnum>.GetDisplayValue(v.WorkingType)}, {EnumHelper<ScheduleEnum>.GetDisplayValue(v.Schedule)}",
                }.SetSalary(v.SalaryMin, v.SalaryMax)).ToList(),
                Page = options.Page,
                PageSize = options.PageSize.AsInt32() ?? -1,
                TotalItemsCount = count
            };
            return response;

        }
    }
}
