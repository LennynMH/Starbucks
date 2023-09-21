import { Item } from "./item.model";
import { MateriaPrima } from "./materiaPrima.model";

export class ItemMateriaPrima {
    public idItemMateriPrima: number = 0;
    public item: Item;
    public materiaPrima: MateriaPrima;
    public precio: number = 0;
}
