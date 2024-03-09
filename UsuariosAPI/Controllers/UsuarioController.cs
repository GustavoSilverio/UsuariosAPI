using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Models.DTO;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] CreateUsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
