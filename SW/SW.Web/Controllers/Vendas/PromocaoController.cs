using System;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SW.Resources;
using SW.Service.Vendas;
using SW.Web.Extensions;

namespace SW.Web.Controllers.Vendas
{
    public class PromocaoController : Controller
    {
        [Dependency]
        public IServicoPromocao ServicoPromocao { get; set; }

        public ActionResult _PartialListagem()
        {
            return View(ServicoPromocao.FindListagem());
        }

        public JavaScriptResult ExcluirPromocao(string id)
        {
            StringBuilder scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            scripts.AppendLine("CarregarListagemPromocoes();");
            try
            {
                ServicoPromocao.ExcluirPromocao(id);
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
