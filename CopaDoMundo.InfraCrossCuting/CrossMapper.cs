using AutoMapper;
using CopaDoMundo.Domain.DTO_s.ResponseModel;

namespace CopaDoMundo.InfraCrossCuting
{
    public class CrossMapper : Profile
    {
        public CrossMapper()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<EnderecoResponseModelCorreto, EnderecoRequestModel>();
            CreateMap<EnderecoRequestModel, EnderecoResponseModelCorreto>();
        }
    }
}
