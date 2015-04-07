using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.Enumeradores;

namespace SW.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.SwDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.SwDbContext context)
        {
            // Promoções base
            context.Promocao.AddOrUpdate(
                p => p.Nome,
                new Promocao { Nome = "Pague 1 e Leve 2", QuantidadeProdutos = 2, TipoCobranca = PromocaoTipoCobranca.ValorUnico },
                new Promocao { Nome = "3 por 10 reais", QuantidadeProdutos = 3, TipoCobranca = PromocaoTipoCobranca.ValorFixo, ValorFixo = 10 }
                );
            // Produtos base
            context.Produto.AddOrUpdate(
                p => p.Nome,
                new Produto { Nome = "A", Preco = 4, PromocaoAtivaId = 2},
                new Produto { Nome = "B", Preco = 25, PromocaoAtivaId = 1 },
                new Produto { Nome = "C", Preco = 4 }
                );
        }
    }
}
