using System.Collections.Generic;

namespace SW.Domain.Vendas.ViewModels
{
    public class ListagemProdutoViewModel
    {
        public List<ProdutoViewModel> Lista { get; set; }

        public ListagemProdutoViewModel()
        {
            Lista = new List<ProdutoViewModel>();
        }
    }
}
