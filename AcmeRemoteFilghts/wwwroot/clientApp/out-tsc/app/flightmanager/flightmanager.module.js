"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var flex_layout_1 = require("@angular/flex-layout");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var toolbar_component_1 = require("./components/toolbar/toolbar.component");
var main_content_component_1 = require("./components/main-content/main-content.component");
var sidenav_component_1 = require("./components/sidenav/sidenav.component");
var http_1 = require("@angular/common/http");
var flightmanager_app_component_1 = require("./flightmanager-app.component");
var material_module_1 = require("../shared/material/material.module");
var flight_service_1 = require("./services/flight.service");
var flight_details_dialog_component_1 = require("./components/flight-details-dialog/flight-details-dialog.component");
var city_service_1 = require("./services/city.service");
var material_1 = require("@angular/material");
var routes = [
    {
        path: '',
        component: flightmanager_app_component_1.FlightmanagerAppComponent,
        children: [
            { path: ':id', component: main_content_component_1.MainContentComponent },
            { path: '', component: main_content_component_1.MainContentComponent }
        ]
    },
    {
        path: '**',
        redirectTo: ''
    }
];
var FlightmanagerModule = /** @class */ (function () {
    function FlightmanagerModule() {
    }
    FlightmanagerModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                http_1.HttpClientModule,
                flex_layout_1.FlexLayoutModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                material_module_1.MaterialModule,
                router_1.RouterModule.forChild(routes)
            ],
            declarations: [
                flightmanager_app_component_1.FlightmanagerAppComponent,
                toolbar_component_1.ToolbarComponent,
                main_content_component_1.MainContentComponent,
                sidenav_component_1.SidenavComponent,
                flight_details_dialog_component_1.FlightDetailsDialogComponent
            ],
            providers: [
                flight_service_1.FlightService,
                city_service_1.CityService,
                { provide: material_1.MAT_DATE_LOCALE, useValue: 'en-AU' }
            ],
            entryComponents: [
                flight_details_dialog_component_1.FlightDetailsDialogComponent
            ],
        })
    ], FlightmanagerModule);
    return FlightmanagerModule;
}());
exports.FlightmanagerModule = FlightmanagerModule;
//# sourceMappingURL=flightmanager.module.js.map