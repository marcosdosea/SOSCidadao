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
    public class PessoaProfile: Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
            CreateMap<PessoaDTO, Pessoa>().ReverseMap();
        }
    }
}
