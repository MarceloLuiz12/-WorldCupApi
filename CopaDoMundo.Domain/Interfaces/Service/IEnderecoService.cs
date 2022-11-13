using CopaDoMundo.Domain.Auxiliar;

namespace CopaDoMundo.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<ResultViewBaseModel> BuscarEndereco(string cep);
    }
}
