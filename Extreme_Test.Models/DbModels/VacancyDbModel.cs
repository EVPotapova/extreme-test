using System;
using System.ComponentModel.DataAnnotations;

namespace Extreme_Test.Models
{
    public class VacancyDbModel
    {
        [Key]
        public int E1Id { get; set; }
        [Required]
        public string Header { get; set; }

        public string Desc { get; set; }

        [Required]
        public string LinkToE1 { get; set; }

        [Required]
        public decimal SalaryMin { get; set; }

        [Required]
        public decimal SalaryMax { get; set; }

        [Required]
        public ExperienceEnum Experience { get; set; }

        [Required]
        public WorkingTypeEnum WorkingType { get; set; }

        [Required]
        public ScheduleEnum Schedule { get; set; }
    }

    //TODO: потенциальная ошибка в будущем если формат данных на сайте изменится
    public enum ExperienceEnum
    {
        [Display(Name ="не указан")]
        NotDefined=0,
        [Display(Name ="без опыта")]
        Zero=1,
        [Display(Name = "до 1 года")]
        LessThanOne,
        [Display(Name = "1-3 года")]
        FromOneToThree,
        [Display(Name = "3-5 лет")]
        FromThreeToFive,
        [Display(Name = "более 5 лет")]
        MoreThanFive
    }
    public enum WorkingTypeEnum
    {
        [Display(Name = "тип занятости не указан")]
        NotDefined = 0,
        [Display(Name = "полная занятость")]
        Full =1,
        [Display(Name = "частичная занятость")]
        Part,
        [Display(Name = "работа вахтовым методом")]
        Shift,
        [Display(Name = "временная работа / freelance")]
        Freelance,
        [Display(Name = "стажировка")]
        Internship
    }
    public enum ScheduleEnum
    {
        [Display(Name = "график работы не указан")]
        NotDefined = 0,
        [Display(Name = "полный рабочий день")]
        FullTime =1,
        [Display(Name = "удаленная работа")]
        Remote,
        [Display(Name = "гибкий график")]
        Flexible,
        [Display(Name = "сменный график")]
        Shift
    }
}
