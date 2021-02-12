using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class OcorrenciaProfile: Profile
    {
        public OcorrenciaProfile()
        {
            CreateMap<OcorrenciaModel, Ocorrencia>().ReverseMap();
        }
        
    }
}
