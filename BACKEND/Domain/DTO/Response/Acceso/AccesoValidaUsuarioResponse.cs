using Domain.Entities;

namespace Domain.DTO.Response.Acceso
{
    public class AccesoValidaUsuarioResponse
    {
        public UsuarioEntity Usuario { get; set; }
        public string Token { get; set; }

    }
}
