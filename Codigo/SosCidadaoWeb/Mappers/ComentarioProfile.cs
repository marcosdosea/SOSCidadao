using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Mappers
{
    public class ComentarioProfile: Profile
    {
        public ComentarioProfile()
        {
            CreateMap<ComentarioModel, Comentario>().ReverseMap();
            CreateMap<ComentarioDTO, Comentario>().ReverseMap();
        }
    }
}
