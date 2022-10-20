using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.Interfaces.Auxiliares;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Domain.Interfaces.Service;
using CopaDoMundo.Infra.Context;

namespace CopaDoMundo.Service
{
    public class CopaDoMundoService : BaseService, ICopaDoMundoService
    {
        private readonly ICopaDoMundoRepository _copaDoMundoRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;

        public CopaDoMundoService(ICopaDoMundoRepository copaDoMundoRepository, IUnitOfWork<AppDbContext> uow)
        {
            _copaDoMundoRepository = copaDoMundoRepository;
            _uow = uow;
        }
        public async  Task<ResultViewBaseModel> BuscarSelecaoAsync(BuscarSelecaoInputModel inputModel)
            => AddResult(await _copaDoMundoRepository.BuscarSelecaoAsync(inputModel));
        public async Task<ResultViewBaseModel> BuscarSeçecaPorNomeAsync(string nome)
            => AddResult(await _copaDoMundoRepository.BuscarSelecaoPorNomeAsync(nome));
        public async Task<ResultViewBaseModel> CriarSelecaoAsync(CadastrarSelecaoInputModel model)
        {
            var selecao = await _copaDoMundoRepository.CriarSelecaoAsync(model);

            if (selecao == null)
                return AddErros(ServiceResource.ErroAoCriarSelecao);

            await _uow.CommitAsync();

            return AddResult(selecao);
        }

        public async Task<ResultViewBaseModel> AlterarSelecaoAsync(AlterarSelecaoInputModel inputModel)
        {
            var selecao = await _copaDoMundoRepository.AlterarSelecaoAsync(inputModel);
            if (selecao == null)
                return AddErros(ServiceResource.SelecaoNaoEncontrada);

            await _uow.CommitAsync();

            return AddResult(selecao);
        }

        public async Task<ResultViewBaseModel> AlterarSituacaoSelecaoAsync(long id)
        {
            if (id <= 0)
                AddErros(ServiceResource.IdInvalido);

            var selecao =  await _copaDoMundoRepository.AlterarSituacaoSelecao(id);

            if (selecao == null)
                return AddErros(ServiceResource.SelecaoNaoEncontrada);

            await _uow.CommitAsync();

            return AddResult(true);
        }
    }
}
