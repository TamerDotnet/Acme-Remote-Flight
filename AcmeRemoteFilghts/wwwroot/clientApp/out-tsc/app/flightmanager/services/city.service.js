"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var CityService = /** @class */ (function () {
    function CityService() {
        this.cityList = [
            { id: 1, cityName: 'Melbourne' },
            { id: 2, cityName: 'Geelong' },
            { id: 3, cityName: 'Ballarat' },
            { id: 4, cityName: 'Bendigo' },
            { id: 5, cityName: 'Melton' },
            { id: 6, cityName: 'Shepparton' },
            { id: 7, cityName: 'Wodonga' }
        ];
    }
    CityService.prototype.getCityList = function () {
        return this.cityList;
    };
    CityService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [])
    ], CityService);
    return CityService;
}());
exports.CityService = CityService;
//# sourceMappingURL=city.service.js.map