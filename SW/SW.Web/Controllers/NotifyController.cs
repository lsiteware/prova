using System.Web.Mvc;
using SW.Web.Models;

namespace SW.Web.Controllers
{
    public class NotifyController : Controller
    {
        public JsonResult VerifyMessage()
        {
            if (TempData.ContainsKey("MESSAGE"))
            {
                MessageViewModel messageModel = TempData["MESSAGE"] as MessageViewModel;
                return Json(new { Type = messageModel.Type.ToString(), Title = messageModel.Title, Message = messageModel.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
    }
}
