using CopaDoMundo.Api.Auxiliar;
using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
using CopaDoMundo.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopaDoMundo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerApi
    {
        private readonly IGerarTokenService _iGerarToken;

        public AutenticacaoController(IGerarTokenService  gerarToken)
         => _iGerarToken = gerarToken;

        [HttpPost("GerarToken")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> GerarToken([FromBody] UserInputModel model)
         => Response(await _iGerarToken.GerarTokenAsync(model));


        [HttpPost("CriarUsuario")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioInputModel model)
        => Response(await _iGerarToken.CriarUsuarioAsync(model));
    }
}
