using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.Domain.Base;
using SW.Resources;

namespace SW.Domain.Vendas
{
    [Table("Promocao")]
    public class Promocao : BaseEntity
    {
        [StringLength(100, ErrorMessageResourceName = "Erro_Validacao_Tamanho_Maximo_Excedido", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Nome", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "QuantidadeProdutos", ResourceType = typeof(PROPRIEDADE))]
        public int QuantidadeProdutos { get; set; }

        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "TipoCobranca", ResourceType = typeof(PROPRIEDADE))]
        public PromocaoTipoCobranca TipoCobranca { get; set; }
    }
}
