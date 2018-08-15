import { City } from "./City";

export class Flight {
    id: number;
    cityFromId: number;
    cityToId: number;
    departTime: Date;
    arriveTime: Date;
    maxPassangers: number;
    availableSeats: number;
    cityFrom: City = new City();
    cityTo: City = new City(); 
}
