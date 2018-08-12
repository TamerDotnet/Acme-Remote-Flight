import { Injectable } from '@angular/core';
import { City } from '../models/City';

@Injectable()
export class CityService {
      cityList: City[] = [
        { id:1, cityName: 'Melbourne'},
        { id: 2, cityName: 'Geelong' },
        { id: 3, cityName: 'Ballarat' },
        { id: 4, cityName: 'Bendigo' },
        { id: 5, cityName: 'Melton' },
        { id: 6, cityName: 'Shepparton' },
        { id: 7, cityName: 'Wodonga' }
    ];
      maxNumbersList: number[] = [5,10,15,20,25,30];
    constructor() { }
    public getCityList(): City[] {
        return this.cityList;
    }
    public getFlightMaxNumberList(): number[] {
        return this.maxNumbersList;
    }

}
