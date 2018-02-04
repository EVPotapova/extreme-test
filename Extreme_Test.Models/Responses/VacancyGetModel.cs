using System;
using System.Collections.Generic;
using System.Text;

namespace Extreme_Test.Models.Responses
{
    public class VacancyGetModel
    {
        public int E1Id { get; set; }

        public string Header { get; set; }

        public string Desc { get; set; }

        public string LinkToE1 { get; set; }

        public string Salary { get; set; }

        public string Info { get; set; }
        

        public VacancyGetModel SetSalary(decimal min, decimal max)
        {
            if (min == 0M && max == 0M)
            {
                Salary = "не указано";
            }
            else if (min == 0 && max != 0)
            {
                Salary = $"до {max:0}";

            }
            else if (min != 0 && max == 0)
            {
                Salary = $"от {min:0}";

            }
            else if (min != 0 && max != 0)
            {
                Salary = $"{min:0}-{max:0}";

            }
            return this;
        }
    }
}
