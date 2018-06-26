import { City } from "./City";

export class Flight {
    id: number;
    cityFrom: City = new City();
    cityTo: City = new City();
    departTime: Date;
    arriveTime: Date;
    maxPassangers: number;
    availableSeats: number;
     
}
