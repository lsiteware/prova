
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SW.Resources;

namespace SW.Domain.Vendas.ViewModels
{
    public class CarrinhoComprasViewModel
    {
        public List<CarrinhoComprasItemViewModel> Itens { get; set; }

        [Display(Name = "VALOR_TOTAL", ResourceType = typeof(PROPRIEDADE))]
        public decimal ValorTotal { get { return Itens == null ? 0 : Itens.Sum(i => i.PrecoTotal); } }

        public CarrinhoComprasViewModel()
        {
            Itens = new List<CarrinhoComprasItemViewModel>();
        }
    }
}
