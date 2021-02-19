using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class ComentarioProfile : Profile
    {
        public ComentarioProfile()
        {
            CreateMap<ComentarioModel, Comentario>().ReverseMap();
            CreateMap<ComentarioDTO, Comentario>().ReverseMap();
        }
    }
}
