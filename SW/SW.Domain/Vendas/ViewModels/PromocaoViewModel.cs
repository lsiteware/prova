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
        [Display(Name = "NOME", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "QUANTIDADE_PRODUTOS", ResourceType = typeof(PROPRIEDADE))]
        public int QuantidadeProdutos { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "TIPO_COBRANCA", ResourceType = typeof(PROPRIEDADE))]
        public PromocaoTipoCobranca TipoCobranca { get; set; }

        [Display(Name = "VALOR_FIXO", ResourceType = typeof(PROPRIEDADE))]
        public decimal? ValorFixo { get; set; }
    }
}
