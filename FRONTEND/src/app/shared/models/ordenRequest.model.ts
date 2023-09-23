import { Orden } from '../entity/orden.model';
import { OrdenItem } from '../entity/ordenItem.model';
export class OrdenRequest extends Orden {
    public listOrdenItem : OrdenItem[] = [];
}
