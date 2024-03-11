using AutoMapper;
using Viacep.Application.Models;
using Viacep.Domain.Entities;

namespace Viacep.Application.Profiles
{
    public class ViacepProfile : Profile
    {
        public ViacepProfile()
        {
            CreateMap<ViacepModel, ViacepResponse>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Cep) ? "N/A" : src.Cep))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Logradouro) ? "N/A" : src.Logradouro))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Complemento) ? "N/A" : src.Complemento))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Bairro) ? "N/A" : src.Bairro))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Localidade) ? "N/A" : src.Localidade))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Uf) ? "N/A" : src.Uf))
                .ForMember(dest => dest.Ibge, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Ibge) ? "N/A" : src.Ibge))
                .ForMember(dest => dest.Gia, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Gia) ? "N/A" : src.Gia))
                .ForMember(dest => dest.Ddd, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Ddd) ? "N/A" : src.Ddd))
                .ForMember(dest => dest.Siafi, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Siafi) ? "N/A" : src.Siafi));
        }
    }
}
