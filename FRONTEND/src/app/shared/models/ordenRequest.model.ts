import { Item } from '../entity/item.model';
import { OrdenItem } from '../entity/ordenItem.model';

export class OrdenRequest extends Item {
    public listOrdenItem : OrdenItem[] = [];
}
