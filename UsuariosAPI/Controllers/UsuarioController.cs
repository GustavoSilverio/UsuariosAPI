using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Models;
using UsuariosAPI.Models.DTO;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario([FromBody] CreateUsuarioDTO usuarioDTO)
        {
            await _usuarioService.Cadastrar(usuarioDTO);
            return Ok("Usuario cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDTO loginDTO)
        {
            var token = await _usuarioService.Login(loginDTO);
            return Ok(token);
        }
    }
}
