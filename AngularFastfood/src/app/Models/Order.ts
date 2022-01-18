import { Accessory, ClassAccessory } from "../Models/Accessory";

export class ClassOrder{
    id: number;
    customerId: number;
    date: Date;
    statusId: number;
}

export interface Order{
    id: number;
    customerId: number;
    date: Date;
    statusId: number;   
}
