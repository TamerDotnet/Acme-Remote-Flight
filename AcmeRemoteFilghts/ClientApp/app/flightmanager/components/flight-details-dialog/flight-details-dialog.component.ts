import { Component, OnInit, Inject, Input } from '@angular/core';
 import { MAT_DIALOG_DATA, MatDialogRef, MatButton } from "@angular/material";
import { Flight } from '../../models/flight';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from '../../services/flight.service';
import { CityService } from '../../services/city.service';
import { City } from '../../models/City';

@Component({
  selector: 'app-flight-details-dialog',
  templateUrl: './flight-details-dialog.component.html',
  styleUrls: ['./flight-details-dialog.component.scss']
})
export class FlightDetailsDialogComponent implements OnInit {
    public cityList: City[];  

    flight: Flight;
    constructor(private route: ActivatedRoute, private flightService: FlightService, private cityService:CityService, 
        private router: Router, private dialogRef: MatDialogRef<FlightDetailsDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Flight) {
        if (data == null) {
            this.flight = new Flight();
        } else {
            this.flight = data;
        }
        
        console.log(JSON.stringify(data));
    }

    ngOnInit() {
        this.cityList = this.cityService.getCityList();
  }

    
    saveFlightDetails(fightDetails: Flight) {   
    
      this.flightService.saveFlightDetails(fightDetails).subscribe(res => {
          this.flightService.changeFlightList(res);
                this.dialogRef.close();
      });
    }
    closeDialog() {
        this.dialogRef.close();
    }     
}
