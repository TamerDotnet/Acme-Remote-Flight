import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { FlightService } from '../../services/flight.service';
import { Flight } from '../../models/flight';

export interface StateGroup {
    letter: string;
    names: string[];
}
export const _filter = (opt: string[], value: string): string[] => {
    const filterValue = value.toLowerCase();

    return opt.filter(item => item.toLowerCase().indexOf(filterValue) === 0);
};

@Component({
    selector: 'app-filter-flight-list',
    templateUrl: './filter-flight-list.component.html',
    styleUrls: ['./filter-flight-list.component.scss']
})
export class FilterFlightListComponent implements OnInit {
    public filteredFlights: Flight[]; 
    stateForm: FormGroup = this.fb.group({
        stateGroup: '',
    });
    stateGroups: StateGroup[] = [{
        letter: 'B',
        names: ['Ballarat', 'Bendigo']
    }, {
        letter: 'G',
        names: ['Geelong']
    }, {
        letter: 'M',
        names: ['Melbourne', 'Melton']

    }, {
        letter: 'S',
        names: ['Shepparton']

    }, {
        letter: 'W',
        names: ['Wodonga']
    }];

    stateGroupOptions: Observable<StateGroup[]>;

    constructor(private fb: FormBuilder, private flightService:FlightService) { }

    ngOnInit() {
        this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
            .pipe(
                startWith(''),
                map(value => this._filterGroup(value))
        );
        this.loadFlights();
    }

    private _filterGroup(value: string): StateGroup[] {
        if (value) {
            return this.stateGroups
                .map(group => ({ letter: group.letter, names: _filter(group.names, value) }))
                .filter(group => group.names.length > 0);
        }

        return this.stateGroups;
    }
    private loadFlights() {
        // load flights from database
        this.flightService.getFlights().subscribe(data => {
            if (data != null) {
                this.filteredFlights = data;
            }
        });
    }

    CityFromSelectedEvent(cityName:string) {
        console.log(cityName);
    }

}
