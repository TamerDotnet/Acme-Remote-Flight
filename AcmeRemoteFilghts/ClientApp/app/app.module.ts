import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
  
import { HttpModule } from '@angular/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
 
const routes: Routes = [
    { path: 'flightmanager', loadChildren: 'app/flightmanager/flightmanager.module#FlightmanagerModule' },
    {path:'**', redirectTo: 'flightmanager'}
]

@NgModule({
  declarations: [
    AppComponent 
  ],
  imports: [
      CommonModule,
      BrowserAnimationsModule,
      BrowserModule,
      HttpModule,
      HttpClientModule, 
      RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
