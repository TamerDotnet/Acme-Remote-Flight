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
var router_1 = require("@angular/router");
var flight_service_1 = require("../../services/flight.service");
var SMALL_WIDTH_BREAKPOINT = 720;
var SidenavComponent = /** @class */ (function () {
    function SidenavComponent(zone, router, flightService) {
        var _this = this;
        this.router = router;
        this.flightService = flightService;
        this.mediaMatcher = matchMedia("(max-width: " + SMALL_WIDTH_BREAKPOINT + "px)");
        this.mediaMatcher.addListener(function (mql) {
            return zone.run(function () { return _this.mediaMatcher = mql; });
        });
    }
    SidenavComponent.prototype.ngOnInit = function () {
        //this.flights = this.flightService.flights;
        //this.flightService.loadFlights();
        var _this = this;
        //this.flights.subscribe(data => {
        //    console.log(data);
        //});
        this.router.events.subscribe(function () {
            if (_this.isScreenSmall()) {
                _this.sidenav.close();
            }
        });
    };
    SidenavComponent.prototype.isScreenSmall = function () {
        return this.mediaMatcher.matches;
    };
    __decorate([
        core_1.ViewChild(material_1.MatSidenav),
        __metadata("design:type", material_1.MatSidenav)
    ], SidenavComponent.prototype, "sidenav", void 0);
    SidenavComponent = __decorate([
        core_1.Component({
            selector: 'app-sidenav',
            templateUrl: './sidenav.component.html',
            styleUrls: ['./sidenav.component.scss']
        }),
        __metadata("design:paramtypes", [core_1.NgZone, router_1.Router, flight_service_1.FlightService])
    ], SidenavComponent);
    return SidenavComponent;
}());
exports.SidenavComponent = SidenavComponent;
//# sourceMappingURL=sidenav.component.js.map