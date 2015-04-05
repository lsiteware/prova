using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.Domain.Base;
using SW.Resources;

namespace SW.Domain.Vendas
{
    [Table("Produto")]
    public class Produto : BaseEntity
    {
        [StringLength(100, ErrorMessageResourceName = "Erro_Validacao_Tamanho_Maximo_Excedido", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Nome", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Preco", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        [Display(Name = "PromocaoAtiva", ResourceType = typeof(PROPRIEDADE))]
        public int? PromocaoAtivaId { get; set; }

        public virtual Promocao PromocaoAtiva { get; set; }
    }
}
