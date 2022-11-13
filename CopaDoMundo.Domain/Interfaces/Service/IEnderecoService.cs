using CopaDoMundo.Domain.DTO_s.ResponseModel;

namespace CopaDoMundo.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<ResponseGenerico<EnderecoResponseModelCorreto>> BuscarEndereco(string cep);
    }
}
