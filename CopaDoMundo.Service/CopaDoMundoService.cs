using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Domain.Interfaces.Service;

namespace CopaDoMundo.Service
{
    public class CopaDoMundoService : ICopaDoMundoService
    {
        private readonly ICopaDoMundoRepository _copaDoMundoRepository;
        public CopaDoMundoService(ICopaDoMundoRepository copaDoMundoRepository)
          => _copaDoMundoRepository = copaDoMundoRepository;

        public Task<List<CopaDoMundoOutPutModel>> BuscarSelecaoAsync()
            => _copaDoMundoRepository.BuscarSelecaoAsync();
        public Task<CopaDoMundoOutPutModel> BuscarSelecaoPorIdAsync(string nome)
            => _copaDoMundoRepository.BuscarSelecaoPorIdAsync(nome);
        public Task<bool> CriarSelecaoAsync(CadastrarSelecaoInputModel model)
            => _copaDoMundoRepository.CriarSelecaoAsync(model);
    }
}
