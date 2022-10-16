using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelecaoCopaDoMundoController : ControllerBase
    {
        private readonly ICopaDoMundoService _copaDoMundoService;

        public SelecaoCopaDoMundoController(ICopaDoMundoService copaDoMundoService)
            => _copaDoMundoService = copaDoMundoService;

        [HttpPost]
        public async Task<IActionResult> CriarSelecao([FromBody] CadastrarSelecaoInputModel model)
        {
            await _copaDoMundoService.CriarSelecaoAsync(model);

            return Ok();
        }

        [HttpGet]
        public async Task<List<CopaDoMundoOutPutModel>> BuscarSelecao()
          => await _copaDoMundoService.BuscarSelecaoAsync();

        [HttpGet("{nome}")]
        public async Task<CopaDoMundoOutPutModel> BuscarSelecaoPorId(string nome)
         => await _copaDoMundoService.BuscarSelecaoPorIdAsync(nome);
    }
}
