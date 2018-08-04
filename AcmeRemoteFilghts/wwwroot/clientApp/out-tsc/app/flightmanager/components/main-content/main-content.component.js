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
var material_1 = require("@angular/material");
var flight_service_1 = require("../../services/flight.service");
var MainContentComponent = /** @class */ (function () {
    function MainContentComponent(flightService) {
        this.flightService = flightService;
        this.displayedColumns = ['id', 'cityFrom', 'cityTo', 'departTime', 'availableSeats'];
    }
    Object.defineProperty(MainContentComponent.prototype, "showAvailableFlights", {
        get: function () {
            return this._showAvailableFlights;
        },
        set: function (value) {
            this._showAvailableFlights = value;
        },
        enumerable: true,
        configurable: true
    });
    MainContentComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.flightService.flightListChange$.subscribe(function (selected) {
            _this.loadFlights();
        });
    };
    MainContentComponent.prototype.loadFlights = function () {
        var _this = this;
        this.flightService.getFlights().subscribe(function (data) {
            if (data != null) {
                _this.flights = data;
                _this.filteredFlights = data;
                _this.dataSource = new material_1.MatTableDataSource(_this.filteredFlights);
            }
        });
    };
    MainContentComponent.prototype.filterFlights = function () {
        this._showAvailableFlights = !this._showAvailableFlights;
        if (this.showAvailableFlights) {
            this.filteredFlights = this.flights.filter(function (flight) {
                return flight.availableSeats > 0;
            });
        }
        else {
            this.filteredFlights = this.flights;
        }
        this.dataSource = new material_1.MatTableDataSource(this.filteredFlights);
    };
    MainContentComponent = __decorate([
        core_1.Component({
            selector: 'app-main-content',
            templateUrl: './main-content.component.html',
            styleUrls: ['./main-content.component.scss']
        }),
        __metadata("design:paramtypes", [flight_service_1.FlightService])
    ], MainContentComponent);
    return MainContentComponent;
}());
exports.MainContentComponent = MainContentComponent;
//# sourceMappingURL=main-content.component.js.map