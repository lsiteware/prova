using System.ComponentModel.DataAnnotations;
using SW.Domain.Base;
using SW.Domain.Vendas.Enumeradores;
using SW.Resources;

namespace SW.Domain.Vendas.ViewModels
{
    public class PromocaoViewModel : ViewModelValidavelBase
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessageResourceName = "ERRO_VALIDACAO_TAMANHO_MAXIMO_EXCEDIDO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Nome", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "QuantidadeProdutos", ResourceType = typeof(PROPRIEDADE))]
        public int QuantidadeProdutos { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "TipoCobranca", ResourceType = typeof(PROPRIEDADE))]
        public PromocaoTipoCobranca TipoCobranca { get; set; }

        [Display(Name = "ValorFixo", ResourceType = typeof(PROPRIEDADE))]
        public decimal? ValorFixo { get; set; }
    }
}
