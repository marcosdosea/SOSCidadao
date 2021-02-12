using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}
