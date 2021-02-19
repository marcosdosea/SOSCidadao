using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class LocalProfile : Profile
    {
        public LocalProfile()
        {
            CreateMap<LocalModel, Local>().ReverseMap();
            CreateMap<LocalDTO, Local>().ReverseMap();
        }
    }
}
