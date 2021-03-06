﻿
using System.Web.Optimization;

namespace SW.Web.App_Start
{
    public class BundleConfig
    {
        public const string SCRIPTS_PATH = "~/Js";
        public const string STYLES_PATH = "~/Css";

        public static void ConfigureBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle(SCRIPTS_PATH)
                .Include("~/Scripts/jquery-2.1.3.min.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/jquery.notify.min.js")
                .Include("~/Scripts/jquery-ui-1.11.4.min.js")
                .Include("~/Scripts/jquery.maskMoney.js"));

            BundleTable.Bundles.Add(new StyleBundle(STYLES_PATH)
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-theme.min.css")
                .Include("~/Content/themes/base/all.css")
                .Include("~/Content/main.css")
                .Include("~/Content/ui.notify.css"));
        }
    }
}