using SW.Domain.Interfaces.Repositorio.Abstrato;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;

namespace SW.Domain.Interfaces.Repositorio.Vendas
{
    public interface IRepositorioPromocao : IRepositorioAbstrato<Promocao, int>
    {
        ListagemPromocaoViewModel FindListagem();
    }
}
