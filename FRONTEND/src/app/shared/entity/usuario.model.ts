import { Rol } from "./rol.model";

export class Usuario {
    public idUsuario: number = 0;
    public rol: Rol = new Rol();
    public documentoIdentidad: string = "";
    public nombre: string = "";
    public apellido: string = "";
    public edad: number = 0;
    public sexo: string = "";
    public correo: string = "";
    public codigo: string = "";
    //public contrasena: string = "";
    public activo: boolean = true;
}
