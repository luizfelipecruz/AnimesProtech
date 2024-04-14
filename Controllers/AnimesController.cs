using AnimesProtech.Context;
using AnimesProtech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet("GetAnimes/{Id}")]
        public IActionResult GetAnime(int Id)
        {
            var Anime = _animeProtech.Animes.Find(Id);

            if (Anime == null)
            {
                return NotFound();
            }
            return Ok(Anime);
        }

        [HttpPut("UpdateAnime/{id}")]
        public ActionResult AtualizarAnime(int id, Anime animerequest)
        {
            try
            {
                // Validação do id
                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                // Validação do animerequest
                if (animerequest == null)
                {
                    return BadRequest("Objeto de requisição inválido.");
                }

                var anime = _animeProtech.Animes.Find(id);

                if (anime == null)
                {
                    return NotFound("Anime não encontrado.");
                }

                // Atualiza as propriedades do anime com as propriedades fornecidas no animerequest
                if (!string.IsNullOrEmpty(animerequest.Name))
                {
                    anime.Name = animerequest.Name;
                }

                if (!string.IsNullOrEmpty(animerequest.synopsis))
                {
                    anime.synopsis = animerequest.synopsis;
                }

                if (!string.IsNullOrEmpty(animerequest.Editor))
                {
                    anime.Editor = animerequest.Editor;
                }

                // Salva as alterações no banco de dados
                _animeProtech.SaveChanges();

                return Ok("Anime atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                // Log de erro
                Console.WriteLine($"Erro ao atualizar anime: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao atualizar o anime.");
            }
        }



    }
}
