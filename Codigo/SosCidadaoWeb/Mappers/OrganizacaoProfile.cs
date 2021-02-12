using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class OrganizacaoProfile : Profile
    {
        public OrganizacaoProfile()
        {
            CreateMap<OrganizacaoModel, Organizacao>().ReverseMap();
        }

    }
}
