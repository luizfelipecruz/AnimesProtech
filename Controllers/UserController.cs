using AnimesProtech.Context;
using AnimesProtech.Models;
using AnimesProtech.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UserController : ControllerBase

    {
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User usuarioRequest)
        {
            try
            {

                NegUser user = new NegUser();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar anime : {ex.Message}");
            }
        }



        [HttpGet("GetUsers/{Login}")]
        public IActionResult GetAnimeList(string login)
        {
            if (!string.IsNullOrEmpty(login))
            {
                NegUser negUser = new NegUser();
                var userList = negUser.list(login);

                if (userList == null || userList.Count == 0)
                {
                    return NotFound("Nenhum usuário encontrado");
                }

                return Ok(userList);
            }

            return BadRequest("Nenhum login fornecido.");
        }




        [HttpPost("UpdateUser/{id}")]
        public IActionResult updateUser(int id, User usuarioRequest)
        {

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            NegUser user = new NegUser();
            try
            {
                user.Update(usuarioRequest);
                return Ok(usuarioRequest);
            }


            catch (Exception)
            {
                return BadRequest("Erro ao atualizar anime ");
            }
        }


        [HttpPut("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            NegUser user = new NegUser();
            try
            {
                if (user.Delete(id))
                {
                    return Ok("Usuario Excluido com sucesso.");
                }

                return BadRequest("Erro ao Deletar anime ");
            }

            catch (Exception)
            {
                return BadRequest("Erro ao Deletar anime ");
            }
        }

    }
}

