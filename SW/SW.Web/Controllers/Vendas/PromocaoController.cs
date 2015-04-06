using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SW.Service.Vendas;

namespace SW.Web.Controllers.Vendas
{
    public class PromocaoController : Controller
    {
        [Dependency]
        public IServicoPromocao ServicoPromocao { get; set; }

        public ActionResult _PartialListagem()
        {
            System.Threading.Thread.Sleep(10000);
            return View(ServicoPromocao.FindListagem());
        }
    }
}
