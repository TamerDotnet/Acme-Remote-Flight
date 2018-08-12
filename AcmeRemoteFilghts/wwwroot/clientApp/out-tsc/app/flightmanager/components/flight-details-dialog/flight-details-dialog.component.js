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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var material_1 = require("@angular/material");
var flight_1 = require("../../models/flight");
var router_1 = require("@angular/router");
var flight_service_1 = require("../../services/flight.service");
var city_service_1 = require("../../services/city.service");
var FlightDetailsDialogComponent = /** @class */ (function () {
    function FlightDetailsDialogComponent(route, flightService, cityService, router, dialogRef, data) {
        this.route = route;
        this.flightService = flightService;
        this.cityService = cityService;
        this.router = router;
        this.dialogRef = dialogRef;
        this.data = data;
        if (data == null) {
            this.flight = new flight_1.Flight();
        }
        else {
            this.flight = data;
        }
    }
    FlightDetailsDialogComponent.prototype.ngOnInit = function () {
        this.cityList = this.cityService.getCityList();
        this.maxNumbersList = this.cityService.getFlightMaxNumberList();
    };
    FlightDetailsDialogComponent.prototype.saveFlightDetails = function (fightDetails) {
        var _this = this;
        this.flightService.saveFlightDetails(fightDetails).subscribe(function (res) {
            _this.flightService.changeFlightList(res);
            _this.dialogRef.close();
        });
    };
    FlightDetailsDialogComponent.prototype.closeDialog = function () {
        this.dialogRef.close();
    };
    FlightDetailsDialogComponent = __decorate([
        core_1.Component({
            selector: 'app-flight-details-dialog',
            templateUrl: './flight-details-dialog.component.html',
            styleUrls: ['./flight-details-dialog.component.scss']
        }),
        __param(5, core_1.Inject(material_1.MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [router_1.ActivatedRoute, flight_service_1.FlightService, city_service_1.CityService,
            router_1.Router, material_1.MatDialogRef,
            flight_1.Flight])
    ], FlightDetailsDialogComponent);
    return FlightDetailsDialogComponent;
}());
exports.FlightDetailsDialogComponent = FlightDetailsDialogComponent;
//# sourceMappingURL=flight-details-dialog.component.js.map