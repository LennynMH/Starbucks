import { Usuario } from "./usuario.model";

export class Orden {
    public idOrden: number = 0;
    public numeroOrden: string = ""; 
    public usuario: Usuario;
    public empleado: Usuario;
    public fechaCreacion:Date   = new Date();
    public activo: boolean = true;
}
