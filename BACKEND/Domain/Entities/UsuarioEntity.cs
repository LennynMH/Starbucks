namespace Domain.Entities
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public RolEntity? Rol { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Codigo { get; set; }
        public string? Contrasena { get; set; }
        public bool Activo { get; set; }
    }
}
