import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vacancy } from './vacancy';
import { VacanciesListResponse } from './vacancy';
import { VacancyFilter } from './vacancy';
import { ListOptions } from './vacancy';

@Injectable()
export class DataService {

    private url = "/api/Vacancy";

    constructor(private http: HttpClient) {
    }


    getVacancies(vacancyFilter: VacancyFilter, listOptions: ListOptions) {
        return this.http.get(this.url, {
            params: {
                page: listOptions.page != null ? listOptions.page.toString() : '1', header: vacancyFilter.header != null ? vacancyFilter.header : '', salaryMin: vacancyFilter.salaryMin != null ? vacancyFilter.salaryMin.toString() : '',
                salaryMax: vacancyFilter.salaryMax != null ? vacancyFilter.salaryMax.toString() : '', experience: vacancyFilter.experience!=null ? vacancyFilter.experience.toString() : ''
            }
        });
    }

    refreshVacanciesList() {

        return this.http.post(this.url + '/refresh', null);
    }
    getVacancy(id: number) {
        return this.http.get(this.url + '/' + id);
    }
}