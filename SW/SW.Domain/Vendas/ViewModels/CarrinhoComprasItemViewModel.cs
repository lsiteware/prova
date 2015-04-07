using System.ComponentModel.DataAnnotations;
using SW.Domain.Base;
using SW.Resources;

namespace SW.Domain.Vendas.ViewModels
{
    public class CarrinhoComprasItemViewModel : ViewModelValidavelBase
    {
        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        public int ProdutoId { get; set; }

        [Display(Name = "ITEM", ResourceType = typeof(PROPRIEDADE))]
        public string ProdutoNome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "QUANTIDADE", ResourceType = typeof(PROPRIEDADE))]
        public int Quantidade { get; set; }

        [Display(Name = "PRECO", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        public int? PromocaoId { get; set; }

        [Display(Name = "PROMOCAO", ResourceType = typeof(PROPRIEDADE))]
        public string PromocaoNome { get; set; }

        public decimal PrecoTotal { get; set; }
    }
}
