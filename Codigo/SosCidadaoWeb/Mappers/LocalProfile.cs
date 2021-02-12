using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class LocalProfile : Profile
    {
        public LocalProfile()
        {
            CreateMap<LocalModel, Local>().ReverseMap();
        }
    }
}
