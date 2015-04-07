using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public override bool IsValid()
        {
            return !MensagensErro().Any();
        }

        public override IEnumerable<string> MensagensErro()
        {
            var errosValidacao = new List<string>();
            if (!ValidarDuplicidadeNome())
            {
                errosValidacao.Add(MENSAGEM.ERRO_PROMOCAO_NOME_DUPLICADO);
            }
            if (!ValidarQuantidadeProdutos())
            {
                errosValidacao.Add(MENSAGEM.ERRO_PROMOCAO_QUANTIDADE_PRODUTOS_ZERADO);
            }
            if (!ValidarTipoCobrancaValorFixo())
            {
                errosValidacao.Add(MENSAGEM.ERRO_PROMOCAO_VALOR_FIXO_ZERADO);
            }
            return errosValidacao;
        }

        public bool ValidarDuplicidadeNome()
        {
            return !Repositorio.FindAll(p => p.Nome == this.Nome && p.Id != this.Id).Any();
        }

        public bool ValidarQuantidadeProdutos()
        {
            return QuantidadeProdutos > 0;
        }

        public bool ValidarTipoCobrancaValorFixo()
        {
            return TipoCobranca == PromocaoTipoCobranca.ValorUnico ||
                   (TipoCobranca == PromocaoTipoCobranca.ValorFixo && ValorFixo > 0);
        }
    }
}
