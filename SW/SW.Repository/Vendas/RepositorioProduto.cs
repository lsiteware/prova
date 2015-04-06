using SW.Domain.Context;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas;
using SW.Repository.Abstrato;

namespace SW.Repository.Vendas
{
    public class RepositorioProduto : RepositorioAbstrato<Produto, int>, IRepositorioProduto
    {
        public RepositorioProduto(SwDbContext context) : base(context) { }
    }
}
