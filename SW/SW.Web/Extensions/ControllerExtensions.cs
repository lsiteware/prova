using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using SW.Web.Models;

namespace SW.Web.Extensions
{
    public static class ControllerExtensions
    {
        #region ViewBage Message

        public static void AddMenssagemAlerta(this Controller controller, string message)
        {
            AddMenssagem(controller, MessageType.ALERT, null, message, 5000);
        }

        public static void AddMenssagemAlerta(this Controller controller, string title, string message)
        {
            AddMenssagem(controller, MessageType.ALERT, title, message, 5000);
        }

        public static void AddMenssagensAlerta(this Controller controller, IEnumerable<string> messages)
        {
            AddMenssagensAlerta(controller, null, messages, 5000);
        }

        public static void AddMenssagensAlerta(this Controller controller, IEnumerable<string> messages, int expires)
        {
            AddMenssagensAlerta(controller, null, messages, expires);
        }

        public static void AddMenssagensAlerta(this Controller controller, string title, IEnumerable<string> messages, int expires)
        {
            if (messages.Count() == 1)
            {
                AddMenssagemAlerta(controller, title, messages.First());
                return;
            }
            var sbAlerts = new StringBuilder();
            sbAlerts.Append("<ul class=\"padd-l-30-px\">");
            messages.ForEach(error => sbAlerts.Append(string.Format("<li type=\"I\">{0}</li>", error)));
            sbAlerts.Append("</ul>");
            AddMenssagem(controller, MessageType.ALERT, title, sbAlerts.ToString(), expires);
        }

        public static void AddMenssagemErro(this Controller controller, string message)
        {
            AddMenssagem(controller, MessageType.ERROR, null, message, 5000);
        }

        public static void AddMenssagemErro(this Controller controller, string title, string message)
        {
            AddMenssagem(controller, MessageType.ERROR, title, message, 5000);
        }

        public static void AddMenssagemErro(this Controller controller, string title, string message, int expires)
        {
            AddMenssagem(controller, MessageType.ERROR, title, message, expires);
        }

        public static void AddMenssagensErro(this Controller controller, IEnumerable<string> messages)
        {
            AddMenssagensErro(controller, null, messages, 5000);
        }


        public static void AddMenssagensErro(this Controller controller, IEnumerable<string> messages, int expires)
        {
            AddMenssagensErro(controller, null, messages, expires);
        }

        public static void AddMenssagensErro(this Controller controller, string title, IEnumerable<string> messages, int expires)
        {
            if (messages.Count() == 1)
            {
                AddMenssagemErro(controller, title, messages.First());
                return;
            }
            var sbErrors = new StringBuilder();
            sbErrors.Append("<ul class=\"padd-l-30-px\">");
            messages.ForEach(error => sbErrors.Append(string.Format("<li type=\"I\">{0}</li>", error)));
            sbErrors.Append("</ul>");
            AddMenssagem(controller, MessageType.ERROR, title, sbErrors.ToString(), expires);
        }

        public static void AddMenssagemSucesso(this Controller controller, string message)
        {
            AddMenssagem(controller, MessageType.SUCCESS, null, message, 5000);
        }

        public static void AddMenssagemSucesso(this Controller controller, string title, string message)
        {
            AddMenssagem(controller, MessageType.SUCCESS, title, message, 5000);
        }

        public static void AddMenssagemSucesso(this Controller controller, string title, string message, int expires)
        {
            AddMenssagem(controller, MessageType.SUCCESS, title, message, expires);
        }

        public static void AddMenssagem(this Controller controller, MessageType type, string title, string message, int expires)
        {
            controller.TempData.Remove("MESSAGE");
            controller.TempData.Add("MESSAGE", new MessageViewModel
            {
                Message = message,
                Title = title,
                Expires = expires,
                Type = type
            });
        }

        #endregion

        //public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        //{
        //    controller.ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
        //        var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
        //        viewResult.View.Render(viewContext, sw);

        //        return sw.GetStringBuilder().ToString();
        //    }
        //}
    }
}