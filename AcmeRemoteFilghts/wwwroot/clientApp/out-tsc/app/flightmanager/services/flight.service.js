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
var rxjs_1 = require("rxjs");
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var FlightService = /** @class */ (function () {
    function FlightService(http) {
        this.http = http;
        this.flightsUrl = 'http://localhost:3235/api/flight/Getflight?numberOfTicketsRequested=2&StartDate=06-01-2018&EndDate=12-30-2018';
        this.saveFlightUrl = 'http://localhost:3235/api/flight/SaveFlight';
        this.flightSource = new rxjs_1.BehaviorSubject(null);
        this.flightListChange$ = this.flightSource.asObservable();
    }
    FlightService.prototype.changeFlightList = function (selectedFlight) {
        this.flightSource.next(selectedFlight);
    };
    FlightService.prototype.getFlights = function () {
        return this.http.get(this.flightsUrl);
    };
    FlightService.prototype.saveFlightDetails = function (flight) {
        var _this = this;
        console.log("flight-service: Start posting  ");
        var headers = new http_1.HttpHeaders().set('content-type', 'application/json');
        return this.http.post(this.saveFlightUrl, flight, {
            headers: headers
        }).pipe(operators_1.tap(function (newFlightData) {
            _this.changeFlightList(newFlightData);
        }));
    };
    FlightService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], FlightService);
    return FlightService;
}());
exports.FlightService = FlightService;
//# sourceMappingURL=flight.service.js.map