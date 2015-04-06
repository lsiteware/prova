using System.ComponentModel.DataAnnotations;
using System.Configuration;
using SW.Core.Utils;
using SW.Resources;

namespace SW.Domain.Vendas.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id
        {
            get
            {
                return string.IsNullOrWhiteSpace(IdSerializado) ? 0 : int.Parse(Encriptar.DesencriptarString(ConfigurationManager.AppSettings["ChaveCriptografia"], IdSerializado));
            }
        }

        public string IdSerializado { get; set; }

        [StringLength(100, ErrorMessageResourceName = "Erro_Validacao_Tamanho_Maximo_Excedido", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Nome", ResourceType = typeof(PROPRIEDADE))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Erro_Validacao_Campo_Obrigatorio", ErrorMessageResourceType = typeof(MENSAGEM))]
        [Display(Name = "Preco", ResourceType = typeof(PROPRIEDADE))]
        public decimal Preco { get; set; }

        [Display(Name = "PromocaoAtiva", ResourceType = typeof(PROPRIEDADE))]
        public int? PromocaoAtivaId { get; set; }

        public virtual PromocaoViewModel PromocaoAtiva { get; set; }
    }
}
