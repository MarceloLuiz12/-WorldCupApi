using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;

namespace CopaDoMundo.Domain.Interfaces.Service
{
    public interface IGerarTokenService
    {
        Task<ResultViewBaseModel> GerarTokenAsync(UserInputModel model);
    }
}
