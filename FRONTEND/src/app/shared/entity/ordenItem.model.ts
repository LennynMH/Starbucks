import { Item } from "./item.model";
import { Orden } from "./orden.model";

export class OrdenItem {
    public idOrdenItem: number = 0;
    public orden: Orden;
    public item: Item;
    public tiempoItem: number   = 0;
    public precio: number = 0;
    public cantidad: number = 0;
}
