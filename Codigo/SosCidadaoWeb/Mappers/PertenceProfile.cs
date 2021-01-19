using AutoMapper;
using Core;
using SosCidadaoWeb.Models;

namespace SosCidadaoWeb.Mappers
{
    public class PertenceProfile: Profile
    {
        public PertenceProfile()
        {
            CreateMap<PertenceModel, Pertence>().ReverseMap();
        }
    }
}
