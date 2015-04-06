using System.Collections.Generic;

namespace SW.Domain.Vendas.ViewModels
{
    public class ListagemPromocaoViewModel
    {
        public List<PromocaoViewModel> Lista { get; set; }

        public ListagemPromocaoViewModel()
        {
            Lista = new List<PromocaoViewModel>();
        }
    }
}
