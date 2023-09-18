using AutoMapper;
using Domain.DTO.Response.Usuario;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperUsuario : Profile
    {
        public AutoMapperUsuario()
        {
            //Usuario
            CreateMap<UsuarioEntity, UsuarioListarByCodigoResponse>();
        }
    }

}
