import { Injectable } from '@angular/core';  
 
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs/Observable';
import {   Response } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Flight } from './flightmanager/models/flight';

@Injectable()
export class FlightService {

    private flightsUrl = 'http://localhost:3235/api/flight/GetFlight?numberOfTicketsRequested=2&StartDate=06-01-2018&EndDate=12-30-2018'; 
    private flightSaveUrl = 'http://localhost:3235/api/flight/SaveFlight';

    private _flights: BehaviorSubject<Flight[]>;
    private dataStore: {
         flights: Flight[]
    }
    get flights(): Observable<Flight[]> {
        return this._flights.asObservable();
    }

    constructor(private http: HttpClient) {
        this.dataStore = { flights: [] };
        this._flights = new BehaviorSubject<Flight[]>([]);
    }
     
    getFlights(): Observable<Flight[]> {
         return this.http.get<Flight[]>(this.flightsUrl);
    }

    saveFlightDetails(flight: Flight): Observable<Flight> {
        const headers = new HttpHeaders().set('content-type', 'application/json');
        return this.http.post<Flight>(this.flightSaveUrl, flight, {
            headers
        });
    }
     
}
