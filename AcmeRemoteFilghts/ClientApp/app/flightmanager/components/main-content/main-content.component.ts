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
    displayedColumns = ['id', 'cityFrom', 'cityTo', 'departTime','availableSeats'];
    dataSource: MatTableDataSource<Flight>;

  constructor(private flightService: FlightService) { }

  ngOnInit() {
       this.flightService.getFlights().subscribe(data => {
   
          if (data != null) {
              this.flights = data;
              console.log(data);
              this.dataSource = new MatTableDataSource<Flight>(this.flights);
          } 
      });
  }

}
