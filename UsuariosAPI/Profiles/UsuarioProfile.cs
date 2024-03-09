using AutoMapper;
using UsuariosAPI.Models.DTO;
using UsuariosAPI.Models;

namespace UsuariosAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }
    }
}
