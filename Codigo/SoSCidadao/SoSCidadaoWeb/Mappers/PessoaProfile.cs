using AutoMapper;
using Core;
using SoSCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoSCidadaoWeb.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile() 
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
