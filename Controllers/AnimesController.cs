using AnimesProtech.Context;
using AnimesProtech.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AnimesProtech.Negocio;
using System.Diagnostics;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Animes")]
    public class AnimesController : Controller
    {

        [HttpPost("CreateAnime")]
        public IActionResult CreateAnime(string name, string synopsis, string editor)
        {

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Informe o nome do anime.");
            }

            if (string.IsNullOrEmpty(synopsis))
            {
                return BadRequest("Informe a sinopse do anime.");
            }

            if (string.IsNullOrEmpty(editor))
            {
                return BadRequest("Informe a sinopse do anime.");
            }


            NegAnimes anime = new NegAnimes();
            try
            {
                anime.Create(name, synopsis, editor);
                if (anime != null)
                {
                    return Ok(anime);
                }
                else
                {
                    return BadRequest("Não foi possivel criar anime");
                }
            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel criar anime");
            }
        }

        [HttpGet("GetAnimes/{id}")]
        public IActionResult GetAnime(int id)
        {
            if (id > 0)
            {

                NegAnimes anime = new NegAnimes();
                anime.find(id);

                if (anime == null)
                {
                    return NotFound("Anime não encontrado");
                }
                return Ok(anime);
            }

            return BadRequest("Anime Não encontrado.");
        }

        [HttpPut("UpdateAnime/{id}")]
        public ActionResult AtualizarAnime(int id, string name, string synopsis, string editor)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID inválido.");
                }

                NegAnimes anime = new NegAnimes();
                anime.update(id, name, synopsis, editor);

                return Ok("Anime atualizado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o anime.");
            }
        }
        [HttpPut("DeleteAnime{id}")]
        public IActionResult DeleteAnime(int id)
        {
            if (id < 0)
            {
                return BadRequest("Insira um Id valido.");
            }
            try
            {
                NegAnimes anime = new NegAnimes();
                anime.delete(id);

                return Ok("Usuario Deletado com Sucesso.");
            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel excluir Anime.");
            }
        }
    }
}
