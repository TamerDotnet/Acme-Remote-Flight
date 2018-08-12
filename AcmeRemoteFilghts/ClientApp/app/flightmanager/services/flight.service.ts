import { Injectable } from '@angular/core';


import { BehaviorSubject, Subject } from 'rxjs';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Flight } from '../models/flight';

@Injectable()
export class FlightService {

    private flightsUrl = 'http://localhost:3235/api/flight?numberOfTicketsRequested=2&StartDate=06-01-2018&EndDate=12-30-2018';
    private saveFlightUrl = 'http://localhost:3235/api/flight';

    private flightSource = new BehaviorSubject<Flight>(null);
    flightListChange$ = this.flightSource.asObservable();

    changeFlightList(selectedFlight: Flight | null): void {
        this.flightSource.next(selectedFlight);
    }

    constructor(private http: HttpClient) {
    }

    getFlights(): Observable<Flight[]> {
        return this.http.get<Flight[]>(this.flightsUrl);
    }
     
    saveFlightDetails(flight: Flight): Observable<Flight> {
        const headers = new HttpHeaders().set('content-type', 'application/json');
        if (flight.id == 0)
            return this.http.post<Flight>(this.saveFlightUrl, flight, {
                headers
            }).pipe(
                tap(newFlightData => {
                    this.changeFlightList(newFlightData);
                }));
        else {
            var updateUrl = this.saveFlightUrl + "/" + flight.id;
            console.log("Update URL IS: " + updateUrl);

            return this.http.put<Flight>(updateUrl, flight, {
                headers
            }).pipe(
                tap(newFlightData => {
                    this.changeFlightList(newFlightData);
                }));
        }
    }
}
