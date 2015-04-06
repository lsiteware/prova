using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public class ServicoPromocao : ServicoAbstrato<Promocao, int, IRepositorioPromocao>, IServicoPromocao
    {
        public ServicoPromocao(IRepositorioPromocao repositorio) : base(repositorio) { }

        public ListagemPromocaoViewModel FindListagem()
        {
            return Repositorio.FindListagem();
        }
        
        public void ExcluirPromocao(string idSerializado)
        {
            var viewModel = new PromocaoViewModel
            {
                IdSerializado = idSerializado
            };
            Repositorio.Delete(viewModel.Id)
                .Save();
        }
    }
}
