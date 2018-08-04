import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
  
import { HttpClientModule } from '@angular/common/http';
import { FlightmanagerAppComponent } from './flightmanager-app.component';
import { MaterialModule } from '../shared/material/material.module';
import { FlightService } from './services/flight.service';
import { FlightDetailsDialogComponent } from './components/flight-details-dialog/flight-details-dialog.component';
import { CityService } from './services/city.service';
import { MAT_DATE_LOCALE } from '@angular/material';
 

let routes: Routes = [
    {
        path: '',
        component: FlightmanagerAppComponent,
        children: [
            { path: ':id', component: MainContentComponent },
            { path: '', component: MainContentComponent }
        ]
    },
    {
        path: '**',
        redirectTo: ''
    }
];
@NgModule({
    imports: [ 
        CommonModule,
        HttpClientModule,
        FlexLayoutModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule.forChild(routes)
   ],
    declarations: [ 
        FlightmanagerAppComponent,
        ToolbarComponent,
        MainContentComponent,
        SidenavComponent,
        FlightDetailsDialogComponent 
    ],
    providers: [
        FlightService,
        CityService,
        { provide: MAT_DATE_LOCALE, useValue: 'en-AU' }
      ],
    entryComponents: [
        FlightDetailsDialogComponent
    ],

    
})
export class FlightmanagerModule { }