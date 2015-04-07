using System.ComponentModel.DataAnnotations;
using SW.Domain.Base;
using SW.Resources;

namespace SW.Domain.Vendas.ViewModels
{
    public class ProdutoViewModel : ViewModelValidavelBase
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessageResourceName = "ERRO_VALIDACAO_TAMANHO_MAXIMO_EXCEDIDO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "NOME", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "PRECO", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        [Display(Name = "PROMOCAO_ATIVA", ResourceType = typeof(PROPRIEDADE))]
        public int? PromocaoAtivaId { get; set; }

        public virtual PromocaoViewModel PromocaoAtiva { get; set; }
    }
}
