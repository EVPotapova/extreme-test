using System;
using System.Collections.Generic;
using System.Text;

namespace Extreme_Test.Models.Filters
{
    public class VacancyFilter
    {
        public string Header { get; set; }//Contains

        public decimal? SalaryMin { get; set; }//>=

        public decimal? SalaryMax { get; set; }//<=

        public ICollection<ExperienceEnum> Experience { get; set; }//Contains

        public ICollection<WorkingTypeEnum> WorkingType { get; set; }//Contains

        public ICollection<ScheduleEnum> Schedule { get; set; }//Contains
    }
}
