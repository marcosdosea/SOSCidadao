using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class TipopertenceProfile : Profile
    {
        public TipopertenceProfile()
        {
            CreateMap<TipopertenceModel, Tipopertence>().ReverseMap();
            CreateMap<TipopertenceDTO, Tipoocorrencia>().ReverseMap();
        }
    }
}
