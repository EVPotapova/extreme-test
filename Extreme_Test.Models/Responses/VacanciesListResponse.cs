using System;
using System.Collections.Generic;
using System.Text;

namespace Extreme_Test.Models.Responses
{
    public abstract class ListResponse<T> where T : class
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalItemsCount { get; set; }
        public ICollection<T> Items { get; set; }
    }

    public class VacanciesListResponse : ListResponse<VacancyGetModel>
    {
    }
}
