using AutoMapper;
using Core;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SosCidadaoWeb.Mappers
{
    public class TipoocorrenciaProfile: Profile
    {
        public TipoocorrenciaProfile()
        {
            CreateMap<TipoocorrenciaModel, Tipoocorrencia>().ReverseMap();
        }
    }
}
