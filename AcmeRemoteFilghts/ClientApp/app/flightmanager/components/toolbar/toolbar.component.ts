import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material';
import { FlightDetailsDialogComponent } from '../flight-details-dialog/flight-details-dialog.component';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  @Output() toggleSidenav = new EventEmitter<void>();

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }


  openFlightDetailsDialog(): void {
      this.dialog.open(FlightDetailsDialogComponent, {
          width: '50%',
      })
  }

}
