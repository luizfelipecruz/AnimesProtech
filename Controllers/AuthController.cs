using AnimesProtech.Context;
using AnimesProtech.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost("LoginUser")]
        public IActionResult CreateUser(string login, string password)
        {
             NegUsuario user = new NegUsuario();
            user.Authenticate(login,password);



            if (user == null)
            {
                return NotFound("Usuario não encontrado.");
            }

            return Ok(user);
        }
    }
}
