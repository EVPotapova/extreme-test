export class Vacancy {
    constructor(
        public e1Id?: number,
        public header?: string,
        public desc?: string,
        public salary?: string,
        public info?: string) { }
}

export class VacanciesListResponse {
    constructor(
        public totalItemsCount?: number,
        public pageSize?: number,
        public items?: Vacancy[]
    ) { }
}

export class VacancyFilter {
    constructor(
        public header?: string,
        public salaryMin?: number,
        public salaryMax?: number,
        public experience?: number[]
        //another filter options
    ) { }
}
export class ListOptions {
    constructor(
        public page?: number) { }
}