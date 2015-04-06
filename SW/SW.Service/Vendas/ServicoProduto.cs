using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public class ServicoProduto : ServicoAbstrato<Produto, int, IRepositorioProduto>, IServicoProduto
    {
        public ServicoProduto(IRepositorioProduto repositorio) : base(repositorio) { }
    }
}
