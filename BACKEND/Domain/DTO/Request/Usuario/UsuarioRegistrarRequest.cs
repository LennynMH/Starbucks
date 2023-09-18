namespace Domain.DTO.Request.Usuario
{
    public class UsuarioRegistrarRequest
    {
        public int IdRol { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Codigo { get; set; }
    }
}
