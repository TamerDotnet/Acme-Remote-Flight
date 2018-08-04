import { Component, OnInit, Input } from '@angular/core';
import { Flight } from '../../models/flight';
import { MatTableDataSource } from '@angular/material';
import { FlightService } from '../../services/flight.service';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {
    public flights: Flight[];
    public filteredFlights: Flight[]; 

    private _showAvailableFlights: boolean;
    get showAvailableFlights(): boolean {
        return this._showAvailableFlights;
    }

    set showAvailableFlights(value: boolean) {
        this._showAvailableFlights = value; 
    }

    displayedColumns = ['id', 'cityFrom', 'cityTo', 'departTime','availableSeats'];
    dataSource: MatTableDataSource<Flight>;

  constructor(private flightService: FlightService) { }

  ngOnInit() { 
      this.flightService.flightListChange$.subscribe(selected => {
          this.loadFlights();
      }); 
  }

  loadFlights() {
      this.flightService.getFlights().subscribe(data => { 
          if (data != null) {
              this.flights = data;
              this.filteredFlights = data;
               this.dataSource = new MatTableDataSource<Flight>(this.filteredFlights);
          }
      });
  }

  filterFlights() {
      this._showAvailableFlights = !this._showAvailableFlights;
      if (this.showAvailableFlights) {
          this.filteredFlights = this.flights.filter((flight) =>  
              flight.availableSeats > 0 );
      } else {
          this.filteredFlights = this.flights;
       }
       this.dataSource = new MatTableDataSource<Flight>(this.filteredFlights);
  }
}
