using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.DTO;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class OrganizacaoProfile : Profile
    {
        public OrganizacaoProfile()
        {
            CreateMap<OrganizacaoModel, Organizacao>().ReverseMap();
            CreateMap<OrganizacaoDTO, Organizacao>().ReverseMap();
        }

    }
}
