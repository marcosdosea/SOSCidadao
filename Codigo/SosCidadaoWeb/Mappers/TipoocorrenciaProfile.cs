using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class TipoocorrenciaProfile : Profile
    {
        public TipoocorrenciaProfile()
        {
            CreateMap<TipoocorrenciaModel, Tipoocorrencia>().ReverseMap();
            CreateMap<TipoocorrenciaDTO, Tipoocorrencia>().ReverseMap();

        }
    }
}
