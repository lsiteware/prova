using SW.Domain.Context;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas;
using SW.Repository.Abstrato;

namespace SW.Repository.Vendas
{
    public class RepositorioPromocao : RepositorioAbstrato<Promocao, int>, IRepositorioPromocao
    {
        public RepositorioPromocao(SwDbContext context) : base(context) { }
    }
}
