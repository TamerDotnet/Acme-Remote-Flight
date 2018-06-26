import { Injectable } from '@angular/core'; 
import { Flight } from '../models/flight'; 
 
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs/Observable';
import {   Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable()
export class FlightService {

    private flightsUrl = 'http://localhost:3235/api/flight?numberOfTicketsRequested=2&StartDate=06-01-2018&EndDate=06-30-2018'; 
  

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
     
}
