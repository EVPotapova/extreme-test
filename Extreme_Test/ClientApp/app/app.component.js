var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Vacancy } from './vacancy';
import { VacanciesListResponse } from './vacancy';
import { VacancyFilter } from './vacancy';
import { ListOptions } from './vacancy';
var AppComponent = (function () {
    function AppComponent(dataService) {
        this.dataService = dataService;
        this.vacancy = new Vacancy();
        this.listOptions = new ListOptions();
        this.vacancyFilter = new VacancyFilter();
        this.vacancies = new VacanciesListResponse();
    }
    AppComponent.prototype.ngOnInit = function () {
        this.loadVacancies();
    };
    AppComponent.prototype.cleanFilter = function () {
        this.vacancyFilter = new VacancyFilter();
        this.listOptions = new ListOptions();
    };
    AppComponent.prototype.loadVacancies = function () {
        var _this = this;
        this.dataService.getVacancies(this.vacancyFilter, this.listOptions)
            .subscribe(function (data) { return _this.vacancies = data; });
    };
    return AppComponent;
}());
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        providers: [DataService]
    }),
    __metadata("design:paramtypes", [DataService])
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map