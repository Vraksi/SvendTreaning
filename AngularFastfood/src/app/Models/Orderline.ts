import { Accessory, ClassAccessory } from "../Models/Accessory";

export class ClassProduct{
    name: string;
    price: number;
    Description: string;
    
}

export interface Product{
    name: string;
    price: number;
    Description: string;
    Accessory: Accessory;
}