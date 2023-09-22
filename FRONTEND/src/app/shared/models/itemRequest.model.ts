import { Item } from '../entity/item.model';
import { ItemMateriaPrima } from '../entity/itemMateriaPrima.model';

export class ItemRequest extends Item {
    public listItemMateriaPrimaEntity : ItemMateriaPrima[] = [];
}
