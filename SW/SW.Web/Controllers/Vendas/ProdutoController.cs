using System;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SW.Resources;
using SW.Service.Vendas;
using SW.Web.Extensions;

namespace SW.Web.Controllers.Vendas
{
    public class ProdutoController : Controller
    {
        [Dependency]
        public IServicoProduto ServicoProduto { get; set; }

        public ActionResult _PartialListagem()
        {
            return View(ServicoProduto.FindListagem());
        }

        public JavaScriptResult ExcluirProduto(string id)
        {
            StringBuilder scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            scripts.AppendLine("CarregarListagemProdutos();");
            try
            {
                ServicoProduto.ExcluirProduto(id);
                this.AddMessageSuccess(TITULO.SUCESSO, MENSAGEM.PRODUTO_EXCLUIDO_SUCESSO, 3000);
            }
            catch (Exception ex)
            {
                this.AddMessageError(TITULO.ERRO, ex.Message, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }
    }
}
