using System.Configuration;
using AutoMapper;
using SW.Core.Utils;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;

namespace SW.Web.App_Start
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigurePromocaoMapping();
            ConfigureProdutoMapping();
        }

        private static void ConfigureProdutoMapping()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IdSerializado, opt => opt.MapFrom(p => Encriptar.EncriptarString(ConfigurationManager.AppSettings["ChaveCriptografia"], p.Id.ToString())))
                .ForMember(dest => dest.PromocaoAtiva, opt => opt.MapFrom(p => Mapper.Map<Promocao, PromocaoViewModel>(p.PromocaoAtiva)));
        }

        private static void ConfigurePromocaoMapping()
        {
            Mapper.CreateMap<Promocao, PromocaoViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IdSerializado, opt => opt.MapFrom(p => Encriptar.EncriptarString(ConfigurationManager.AppSettings["ChaveCriptografia"], p.Id.ToString())));
        }
    }
}