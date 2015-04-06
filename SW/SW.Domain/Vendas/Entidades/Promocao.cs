using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.Domain.Base;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Enumeradores;
using SW.Resources;

namespace SW.Domain.Vendas.Entidades
{
    [Table("Promocao")]
    public class Promocao : EntidadeBase
    {
        [NotMapped]
        public static IRepositorioPromocao Repositorio { get; set; }

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
