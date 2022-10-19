using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.InputModels;

namespace CopaDoMundo.Domain.Interfaces.Service
{
    public interface ICopaDoMundoService
    {
        Task<ResultViewBaseModel> CriarSelecaoAsync(CadastrarSelecaoInputModel model);
        Task<ResultViewBaseModel> BuscarSelecaoAsync(BuscarSelecaoInputModel inputModel);
        Task<ResultViewBaseModel> BuscarSeçecaPorNomeAsync(string nome);
        Task<ResultViewBaseModel> AlterarSelecaoAsync(AlterarSelecaoInputModel inputModel);
        Task<ResultViewBaseModel> AlterarSituacaoSelecaoAsync(long id);
    }
}
