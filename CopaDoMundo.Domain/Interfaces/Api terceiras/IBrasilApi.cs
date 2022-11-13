using CopaDoMundo.Domain.DTO_s.ResponseModel;

namespace CopaDoMundo.Domain.Interfaces.Api_terceiras
{
    public interface IBrasilApi
    {
        Task<ResponseGenerico<EnderecoRequestModel>> BuscarEnderecoPorCep(string cep);
        Task<ResponseGenerico<List<BancoRequestModel>>> BuscarTodosBancos();
        Task<ResponseGenerico<BancoRequestModel>> BuscarBanco(string codigoBanco);
    }
}
