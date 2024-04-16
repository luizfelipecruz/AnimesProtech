using AnimesProtech.Context;
using AnimesProtech.Models;
using AnimesProtech.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase

    {
    

    

       

        [HttpPost("UpdateUser/{id}")]
        public IActionResult updateUser(int id, Usuario usuarioRequest)
        {
            try
            {

                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                NegUsuario user = new NegUsuario();
                user.Authenticate(usuarioRequest.Login, usuarioRequest.Password);
                

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar anime : {ex.Message}");
            }
        }

    }
}

