using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SW.Service.Vendas;

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
    }
}
