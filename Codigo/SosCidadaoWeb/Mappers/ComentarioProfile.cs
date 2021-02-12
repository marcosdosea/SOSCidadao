using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<ComentarioModel, Comentario>().ReverseMap();
        }
    }
}
