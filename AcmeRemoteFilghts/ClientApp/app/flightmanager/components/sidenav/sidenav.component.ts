import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { Router } from '@angular/router';
import { FlightService } from '../../services/flight.service';
import { Observable } from 'rxjs/Observable';
import { Flight } from '../../models/flight';
const SMALL_WIDTH_BREAKPOINT = 720;
@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
    private mediaMatcher: MediaQueryList =
    matchMedia(`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`);

    flights: Observable<Flight[]>;
    constructor(zone: NgZone, private router: Router, private flightService:FlightService) {
        this.mediaMatcher.addListener(mql =>
            zone.run(() => this.mediaMatcher = mql));
    }
    @ViewChild(MatSidenav) sidenav: MatSidenav;
    ngOnInit() {
        //this.flights = this.flightService.flights;
        //this.flightService.loadFlights();

        //this.flights.subscribe(data => {
        //    console.log(data);
        //});

        this.router.events.subscribe(() => {
            if (this.isScreenSmall()) {
                this.sidenav.close();
            }
        });
  }
    isScreenSmall(): boolean {
        return this.mediaMatcher.matches;
    }

}
