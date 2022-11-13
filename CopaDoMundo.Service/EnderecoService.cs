using AutoMapper;
using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.ResponseModel;
using CopaDoMundo.Domain.Interfaces.Api_terceiras;
using CopaDoMundo.Domain.Interfaces.Service;
using System.Net;

namespace CopaDoMundo.Service
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public EnderecoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResultViewBaseModel> BuscarEndereco(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return AddErros(ServiceResource.CepInvalido);

            var endereco = await _brasilApi.BuscarEnderecoPorCep(cep);

            if (endereco.CodigoHttp == HttpStatusCode.OK)
                return AddResult(_mapper.Map<ResponseGenerico<EnderecoResponseModelCorreto>>(endereco));

            return AddErros(ServiceResource.CepNaoEncontrado);
        }
    }
}
