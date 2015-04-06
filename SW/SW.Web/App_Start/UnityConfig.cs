using System;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using SW.Domain.Context;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Repository.Vendas;
using SW.Service.Vendas;

namespace SW.Web.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            // Contexto
            container.RegisterType<DbContext, SwDbContext>();

            // Repositórios
            container.RegisterType<IRepositorioProduto, RepositorioProduto>();
            container.RegisterType<IRepositorioPromocao, RepositorioPromocao>();

            // Serviços
            container.RegisterType<IServicoProduto, ServicoProduto>();
            container.RegisterType<IServicoPromocao, ServicoPromocao>();

            // Repositórios das entidades
            Produto.Repositorio = container.Resolve<IRepositorioProduto>();
            Promocao.Repositorio = container.Resolve<IRepositorioPromocao>();
        }
    }
}
