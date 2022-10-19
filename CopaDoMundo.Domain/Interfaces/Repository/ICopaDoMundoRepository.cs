using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModelAuxiliar;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Entities;

namespace CopaDoMundo.Domain.Interfaces.Repository
{
    public interface ICopaDoMundoRepository
    {
        Task<SelecaoEntity> CriarSelecaoAsync(CadastrarSelecaoInputModel model);
        Task<PaginadoOutputModel<CopaDoMundoOutPutModel>> BuscarSelecaoAsync(BuscarSelecaoInputModel inputModel);
        Task<CopaDoMundoOutPutModel> BuscarSelecaoPorIdAsync(string nome);
    }
}
