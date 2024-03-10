using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;
using UsuariosAPI.Models.DTO;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDTO usuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

            var resultado = await _userManager.CreateAsync(usuario, usuarioDTO.Password);

            if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
        }

        public async Task<string> Login(LoginUsuarioDTO loginDTO)
        {
            var resultado = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);
            if (!resultado.Succeeded) throw new ApplicationException("Usuario não autenticado!");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == loginDTO.Username.ToUpper());

            return _tokenService.GenerateToken(usuario);
        }
    }
}
