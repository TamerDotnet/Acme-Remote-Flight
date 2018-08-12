import { Component, OnInit, Input } from '@angular/core';
import { Flight } from '../../models/flight';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { FlightService } from '../../services/flight.service';
import { FlightDetailsDialogComponent } from '../flight-details-dialog/flight-details-dialog.component';

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
    //set datasource for the MatTable
    displayedColumns = ['id', 'cityFrom', 'cityTo', 'departTime','availableSeats','update','delete'];
    dataSource: MatTableDataSource<Flight>;

    constructor(private flightService: FlightService,
        private dialog: MatDialog) {

    }

  ngOnInit() { 
      //subscrib to changes in flight list from database
      this.flightService.flightListChange$.subscribe(selected => {
          this.loadFlights();
      }); 
  }

  loadFlights() {
       // load flights from database
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

  openFlightDetailsDialog(flight: Flight): void { 
      this.dialog.open(FlightDetailsDialogComponent, {
          width: '50%',
          data: flight
      })
  }
}
