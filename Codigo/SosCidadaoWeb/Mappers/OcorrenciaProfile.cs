using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class OcorrenciaProfile : Profile
    {
        public OcorrenciaProfile()
        {
            CreateMap<OcorrenciaModel, Ocorrencia>().ReverseMap();
            CreateMap<OcorrenciaDTO, Ocorrencia>().ReverseMap();
        }
    }
}
