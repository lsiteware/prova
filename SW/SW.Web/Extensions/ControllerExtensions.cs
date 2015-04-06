using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using SW.Web.Models;

namespace SW.Web.Extensions
{
    public static class ControllerExtensions
    {
        #region ViewBage Message

        public static void AddMessageAlert(this Controller controller, string message)
        {
            AddMessage(controller, MessageType.ALERT, null, message, 5000);
        }

        public static void AddMessageAlert(this Controller controller, string title, string message)
        {
            AddMessage(controller, MessageType.ALERT, title, message, 5000);
        }

        public static void AddMessagesAlert(this Controller controller, List<string> messages)
        {
            AddMessagesAlert(controller, null, messages, 5000);
        }

        public static void AddMessagesAlert(this Controller controller, List<string> messages, int expires)
        {
            AddMessagesAlert(controller, null, messages, expires);
        }

        public static void AddMessagesAlert(this Controller controller, string title, List<string> messages, int expires)
        {
            if (messages.Count == 1)
            {
                AddMessageAlert(controller, title, messages[0]);
                return;
            }
            StringBuilder sbAlerts = new StringBuilder();
            sbAlerts.Append("<ul class=\"padd-l-30-px\">");
            messages.ForEach(error =>
            {
                sbAlerts.Append(string.Format("<li type=\"I\">{0}</li>", error));
            });
            sbAlerts.Append("</ul>");
            AddMessage(controller, MessageType.ALERT, title, sbAlerts.ToString(), expires);
        }

        public static void AddMessageError(this Controller controller, string message)
        {
            AddMessage(controller, MessageType.ERROR, null, message, 5000);
        }

        public static void AddMessageError(this Controller controller, string title, string message)
        {
            AddMessage(controller, MessageType.ERROR, title, message, 5000);
        }

        public static void AddMessageError(this Controller controller, string title, string message, int expires)
        {
            AddMessage(controller, MessageType.ERROR, title, message, expires);
        }

        public static void AddMessagesError(this Controller controller, List<string> messages)
        {
            AddMessagesError(controller, null, messages, 5000);
        }


        public static void AddMessagesError(this Controller controller, List<string> messages, int expires)
        {
            AddMessagesError(controller, null, messages, expires);
        }

        public static void AddMessagesError(this Controller controller, string title, List<string> messages, int expires)
        {
            if (messages.Count == 1)
            {
                AddMessageError(controller, title, messages[0]);
                return;
            }
            StringBuilder sbErrors = new StringBuilder();
            sbErrors.Append("<ul class=\"padd-l-30-px\">");
            messages.ForEach(error =>
            {
                sbErrors.Append(string.Format("<li type=\"I\">{0}</li>", error));
            });
            sbErrors.Append("</ul>");
            AddMessage(controller, MessageType.ERROR, title, sbErrors.ToString(), expires);
        }

        public static void AddMessageSuccess(this Controller controller, string message)
        {
            AddMessage(controller, MessageType.SUCCESS, null, message, 5000);
        }

        public static void AddMessageSuccess(this Controller controller, string title, string message)
        {
            AddMessage(controller, MessageType.SUCCESS, title, message, 5000);
        }

        public static void AddMessageSuccess(this Controller controller, string title, string message, int expires)
        {
            AddMessage(controller, MessageType.SUCCESS, title, message, expires);
        }

        public static void AddMessage(this Controller controller, MessageType type, string title, string message, int expires)
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

        public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}