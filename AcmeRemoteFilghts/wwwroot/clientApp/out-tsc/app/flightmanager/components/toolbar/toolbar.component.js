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
var flight_details_dialog_component_1 = require("../flight-details-dialog/flight-details-dialog.component");
var ToolbarComponent = /** @class */ (function () {
    function ToolbarComponent(dialog) {
        this.dialog = dialog;
        this.toggleSidenav = new core_1.EventEmitter();
    }
    ToolbarComponent.prototype.ngOnInit = function () {
    };
    ToolbarComponent.prototype.openFlightDetailsDialog = function () {
        this.dialog.open(flight_details_dialog_component_1.FlightDetailsDialogComponent, {
            width: '50%',
        });
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", Object)
    ], ToolbarComponent.prototype, "toggleSidenav", void 0);
    ToolbarComponent = __decorate([
        core_1.Component({
            selector: 'app-toolbar',
            templateUrl: './toolbar.component.html',
            styleUrls: ['./toolbar.component.scss']
        }),
        __metadata("design:paramtypes", [material_1.MatDialog])
    ], ToolbarComponent);
    return ToolbarComponent;
}());
exports.ToolbarComponent = ToolbarComponent;
//# sourceMappingURL=toolbar.component.js.map