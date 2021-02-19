using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class PertenceProfile : Profile
    {
        public PertenceProfile()
        {
            CreateMap<PertenceModel, Pertence>().ReverseMap();
            CreateMap<PertenceDTO, Pertence>().ReverseMap();
        }
    }
}
