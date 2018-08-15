import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

import { Observable } from 'rxjs/Observable'; 
import { map } from 'rxjs/operator/map';
import { startWith } from 'rxjs/operators/startWith';


export class State {
    constructor(public name: string, public population: string, public flag: string) { }
}



@Component({
    selector: 'app-filter-flight-list',
    templateUrl: './filter-flight-list.component.html',
    styleUrls: ['./filter-flight-list.component.scss']
})
export class FilterFlightListComponent implements OnInit {

    stateCtrl: FormControl;
    filteredStates: Observable<any[]>;
    options: string[] = ['One', 'Two', 'Three'];

    ngOnInit(): void {
        //this.filteredStates = this.stateCtrl.valueChanges
        //    .pipe(
        //        startWith(''),
        //        map(value => this._filter(value))
        //    );
    }
    private _filter(value: string): string[] {
        const filterValue = value.toLowerCase();

        return this.options.filter(option => option.toLowerCase().includes(filterValue));
    }
     
    states: State[] = [
        {
            name: 'Arkansas',
            population: '2.978M',
            // https://commons.wikimedia.org/wiki/File:Flag_of_Arkansas.svg
            flag: 'https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg'
        },
        {
            name: 'California',
            population: '39.14M',
            // https://commons.wikimedia.org/wiki/File:Flag_of_California.svg
            flag: 'https://upload.wikimedia.org/wikipedia/commons/0/01/Flag_of_California.svg'
        },
        {
            name: 'Florida',
            population: '20.27M',
            // https://commons.wikimedia.org/wiki/File:Flag_of_Florida.svg
            flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg'
        },
        {
            name: 'Texas',
            population: '27.47M',
            // https://commons.wikimedia.org/wiki/File:Flag_of_Texas.svg
            flag: 'https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg'
        }
    ];

    constructor() {
        this.stateCtrl = new FormControl();
    }




    filterStates(name: string) {
        return this.states.filter(state =>
            state.name.toLowerCase().indexOf(name.toLowerCase()) === 0);
    }

    onEnter(evt: any) {
        if (evt.source.selected) {
            alert("hello ");
        }
    }

}
