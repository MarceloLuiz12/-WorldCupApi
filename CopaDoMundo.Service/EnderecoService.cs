using AutoMapper;
using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.DTO_s.ResponseModel;
using CopaDoMundo.Domain.Interfaces.Api_terceiras;
using CopaDoMundo.Domain.Interfaces.Service;

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

        public async Task<ResponseGenerico<EnderecoResponseModelCorreto>> BuscarEndereco(string cep)
        {
            var endereco = await _brasilApi.BuscarEnderecoPorCep(cep);
            return _mapper.Map<ResponseGenerico<EnderecoResponseModelCorreto>>(endereco);
        }
    }
}
