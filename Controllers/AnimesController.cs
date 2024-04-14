using AnimesProtech.Context;
using AnimesProtech.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Animes")]
    public class AnimesController : Controller
    {
        private readonly AnimeProtech _animeProtech;
        public AnimesController(AnimeProtech animeProtech)
        {
            _animeProtech = animeProtech;
        }
        [HttpPost("CreateAnime")]
        public IActionResult CreateAnime(Anime anime)
        {
            _animeProtech.Add(anime);
            _animeProtech.SaveChanges();
            return Ok(anime);
        } 
    }
}
