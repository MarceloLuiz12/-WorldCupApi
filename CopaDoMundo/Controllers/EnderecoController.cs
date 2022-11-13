using CopaDoMundo.Api.Auxiliar;
using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopaDoMundo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerApi
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
           => _enderecoService = enderecoService;

        [HttpGet("BuscarEndereco")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarEndereco([FromQuery] string cep)
        {
            var response = await _enderecoService.BuscarEndereco(cep);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}
