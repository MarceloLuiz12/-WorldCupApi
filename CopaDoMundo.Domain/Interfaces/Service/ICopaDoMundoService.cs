using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModels;

namespace CopaDoMundo.Domain.Interfaces.Service
{
    public interface ICopaDoMundoService
    {
        Task<bool> CriarSelecaoAsync(CadastrarSelecaoInputModel model);
        Task<List<CopaDoMundoOutPutModel>> BuscarSelecaoAsync();
        Task<CopaDoMundoOutPutModel> BuscarSelecaoPorIdAsync(string nome);
    }
}
