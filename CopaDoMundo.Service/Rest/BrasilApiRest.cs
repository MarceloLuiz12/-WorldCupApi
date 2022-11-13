using CopaDoMundo.Domain.DTO_s.ResponseModel;
using CopaDoMundo.Domain.Interfaces.Api_terceiras;
using System.Dynamic;
using System.Text.Json;

namespace CopaDoMundo.Service.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
        public Task<ResponseGenerico<BancoRequestModel>> BuscarBanco(string codigoBanco)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseGenerico<List<BancoRequestModel>>> BuscarTodosBancos()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGenerico<EnderecoRequestModel>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new ResponseGenerico<EnderecoRequestModel>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var conteudoResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoRequestModel>(conteudoResponse);

                if (!responseBrasilApi.IsSuccessStatusCode)
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(conteudoResponse);

                response.DadosRetorno = objResponse;
                response.CodigoHttp = responseBrasilApi.StatusCode;
            }
            return response;
        }
    }
}
