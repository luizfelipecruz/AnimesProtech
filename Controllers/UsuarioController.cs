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
        public IActionResult CreateAnime(Anime anime)
        {
            _animeProtech.Add(anime);
            _animeProtech.SaveChanges();
            return Ok(anime);
        }
    }
}

