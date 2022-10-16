using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModels;

namespace CopaDoMundo.Domain.Interfaces.Repository
{
    public interface ICopaDoMundoRepository
    {
        Task<bool> CriarSelecaoAsync(CadastrarSelecaoInputModel model);
        Task<List<CopaDoMundoOutPutModel>> BuscarSelecaoAsync();
        Task<CopaDoMundoOutPutModel> BuscarSelecaoPorIdAsync(long id);
    }
}
