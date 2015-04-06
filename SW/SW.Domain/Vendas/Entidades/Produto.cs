using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.Domain.Base;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Resources;

namespace SW.Domain.Vendas.Entidades
{
    [Table("Produto")]
    public class Produto : EntidadeBase
    {
        [NotMapped]
        public static IRepositorioProduto Repositorio { get; set; }

        [StringLength(100, ErrorMessageResourceName = "ERRO_VALIDACAO_TAMANHO_MAXIMO_EXCEDIDO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Nome", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Preco", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        [Display(Name = "PromocaoAtiva", ResourceType = typeof(PROPRIEDADE))]
        public int? PromocaoAtivaId { get; set; }

        public virtual Promocao PromocaoAtiva { get; set; }
    }
}
