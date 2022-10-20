using CopaDoMundo.Api.Auxiliar;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
using CopaDoMundo.Infra.Repository.RepositoryAutenticacao;
using CopaDoMundo.Service;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerApi
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] UserModel model)
        {
            var usuario =  UserRepository.BuscarUsuario(model.Username, model.Password);

            if (usuario == null)
                return BadRequest(new { message = "Usuário ou senha inválidos" });

            var token =  AutenticacaoService.GerarToken(usuario);

            usuario.Password = string.Empty;

            return new { User = usuario, Token = token };
        }
    }
}
