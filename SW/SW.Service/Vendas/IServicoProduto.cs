using SW.Domain.Vendas;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public interface IServicoProduto : IServicoAbstrato<Produto, int>
    {
    }
}
