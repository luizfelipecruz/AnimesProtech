using AnimesProtech.Context;
using AnimesProtech.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase

    {
        private readonly AnimeProtech _animeProtech;

        public UsuarioController(AnimeProtech animeProtech)
        {
            _animeProtech = animeProtech;
        }

        [HttpPost("LoginUser")]
        public IActionResult CreateUser(string login, string senha)
        {
            var Anime = _animeProtech.usuarios.Find(login);

            if (Anime == null)
            {
                return NotFound("Usuario não encontrado.");
            }

            return Ok(Anime);
        }

        [HttpPost("UpdateUser/{id}")]
        public IActionResult updateUser(int id, Usuario usuarioRequest)
        {
            try
            {

                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                var usuario = _animeProtech.usuarios.Find(id);

                if (usuario != null)
                {
                    if (!string.IsNullOrEmpty(usuarioRequest.Login))
                    {
                        usuario.Login = usuarioRequest.Login;
                    }

                    if (!string.IsNullOrEmpty(usuarioRequest.Email))
                    {
                        usuario.Email = usuarioRequest.Email;
                    }
                    if (usuarioRequest.Password != null)
                    {
                        usuario.Password = usuarioRequest.Password;
                    }
                    _animeProtech.SaveChanges();
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar anime : {ex.Message}");
            }
        }

    }
}

