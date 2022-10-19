using CopaDoMundo.Api.Auxiliar;
using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModelAuxiliar;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CopaDoMundo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelecaoCopaDoMundoController : ControllerApi
    {
        private readonly ICopaDoMundoService _copaDoMundoService;

        public SelecaoCopaDoMundoController(ICopaDoMundoService copaDoMundoService)
            => _copaDoMundoService = copaDoMundoService;

        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> CriarSelecao([FromBody] CadastrarSelecaoInputModel model)
         => Response(await _copaDoMundoService.CriarSelecaoAsync(model));

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<PaginadoOutputModel<SelecaoOutPutModel>>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarSelecao([FromQuery] BuscarSelecaoInputModel inputModel)
          => Response(await _copaDoMundoService.BuscarSelecaoAsync(inputModel));

        [HttpGet("{nome}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarSelecaoPorId(string nome)
         => Response(await _copaDoMundoService.BuscarSeçecaPorNomeAsync(nome));

        [HttpPut]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarCadastroClienteAsync(AlterarSelecaoInputModel model)
          => Response(await _copaDoMundoService.AlterarSelecaoAsync(model));

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarSituacaoCliente(long id)
            => Response(await _copaDoMundoService.AlterarSituacaoSelecaoAsync(id));
    }
}
