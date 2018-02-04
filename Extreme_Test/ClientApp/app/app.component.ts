import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Vacancy } from './vacancy';
import { VacanciesListResponse } from './vacancy';
import { VacancyFilter } from './vacancy';
import { ListOptions } from './vacancy';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    vacancy: Vacancy = new Vacancy();
    listOptions: ListOptions = new ListOptions();
    vacancyFilter: VacancyFilter = new VacancyFilter();   
    vacancies: VacanciesListResponse = new VacanciesListResponse();   

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadVacancies();    
    }
    cleanFilter() {
        this.vacancyFilter = new VacancyFilter();
        this.listOptions = new ListOptions();
    }
    loadVacancies() {
        this.dataService.getVacancies(this.vacancyFilter, this.listOptions)
            .subscribe((data: VacanciesListResponse) => this.vacancies = data);
    }
}