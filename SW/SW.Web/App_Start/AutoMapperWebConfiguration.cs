using AutoMapper;
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
                .ForMember(dest => dest.PromocaoAtiva, opt => opt.MapFrom(p => Mapper.Map<Promocao, PromocaoViewModel>(p.PromocaoAtiva)));
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }

        private static void ConfigurePromocaoMapping()
        {
            Mapper.CreateMap<Promocao, PromocaoViewModel>();
            Mapper.CreateMap<PromocaoViewModel, Promocao>();
        }
    }
}