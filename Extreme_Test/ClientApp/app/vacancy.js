var Vacancy = (function () {
    function Vacancy(e1Id, header, desc, salary, info) {
        this.e1Id = e1Id;
        this.header = header;
        this.desc = desc;
        this.salary = salary;
        this.info = info;
    }
    return Vacancy;
}());
export { Vacancy };
var VacanciesListResponse = (function () {
    function VacanciesListResponse(totalItemsCount, pageSize, items) {
        this.totalItemsCount = totalItemsCount;
        this.pageSize = pageSize;
        this.items = items;
    }
    return VacanciesListResponse;
}());
export { VacanciesListResponse };
var VacancyFilter = (function () {
    function VacancyFilter(header, salaryMin, salaryMax, experience
        //another filter options
    ) {
        this.header = header;
        this.salaryMin = salaryMin;
        this.salaryMax = salaryMax;
        this.experience = experience;
    }
    return VacancyFilter;
}());
export { VacancyFilter };
var ListOptions = (function () {
    function ListOptions(page) {
        this.page = page;
    }
    return ListOptions;
}());
export { ListOptions };
//# sourceMappingURL=vacancy.js.map