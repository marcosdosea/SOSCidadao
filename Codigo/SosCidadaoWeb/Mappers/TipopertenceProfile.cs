using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class TipopertenceProfile : Profile
    {
        public TipopertenceProfile()
        {
            CreateMap<TipopertenceModel, Tipopertence>().ReverseMap();
        }
    }
}
