using SW.Domain.Vendas.ViewModels;

namespace SW.Service.Vendas
{
    public interface IServicoCarrinhoCompras
    {
        void AdicionarProduto(CarrinhoComprasViewModel carrinhoCompras, int? produtoId, int? quantidade);

        void RemoverProduto(CarrinhoComprasViewModel carrinhoCompras, int produtoId);
    }
}
