using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public class ServicoPromocao : ServicoAbstrato<Promocao, int, IRepositorioPromocao>, IServicoPromocao
    {
        public ServicoPromocao(IRepositorioPromocao repositorio) : base(repositorio) { }
    }
}
