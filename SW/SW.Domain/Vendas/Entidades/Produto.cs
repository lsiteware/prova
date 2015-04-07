using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        [Display(Name = "NOME", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "ERRO_VALIDACAO_CAMPO_OBRIGATORIO", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "PRECO", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        [Display(Name = "PROMOCAO_ATIVA", ResourceType = typeof(PROPRIEDADE))]
        public int? PromocaoAtivaId { get; set; }

        public virtual Promocao PromocaoAtiva { get; set; }

        public override bool IsValid()
        {
            return !MensagensErro().Any();
        }

        public override IEnumerable<string> MensagensErro()
        {
            var errosValidacao = new List<string>();
            if (!ValidarDuplicidadeNome())
            {
                errosValidacao.Add(MENSAGEM.ERRO_PRODUTO_NOME_DUPLICADO);
            }
            if (!ValidarPreco())
            {
                errosValidacao.Add(MENSAGEM.ERRO_PRODUTO_VALOR_ZERADO);
            }
            return errosValidacao;
        }

        public bool ValidarDuplicidadeNome()
        {
            return !Repositorio.FindAll(p => p.Nome == this.Nome && p.Id != this.Id).Any();
        }

        public bool ValidarPreco()
        {
            return Preco > 0;
        }
    }
}
