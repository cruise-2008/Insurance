using System.Web.Optimization;

namespace Insurance
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common")
                .Include("~/Scripts/jquery-1.12.1.js")
                .Include("~/Scripts/jquery.arcticmodal.js")
                .Include("~/Scripts/jquery.fancybox.min.js")
                .Include("~/Scripts/jquery.nice-select.js")
                .Include("~/Scripts/jquery.jscrollpane.js")
                .Include("~/Scripts/jquery.mousewheel.js")
                .Include("~/Scripts/toastr.js")
                .Include("~/Scripts/mask.js")
                .Include("~/Scripts/ctm/route.js")
                .Include("~/Scripts/ctm/common.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/head")
                .Include("~/Scripts/ctm/head.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/home")
                .Include("~/Scripts/ctm/home.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/osago")
                .Include("~/Scripts/ctm/gsearch.js")
                .Include("~/Scripts/ctm/osago.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/tourist")
                .Include("~/Scripts/ctm/tourist.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/greencard")
                .Include("~/Scripts/ctm/greencard.js")
                );

            bundles.Add(new StyleBundle("~/css")
                .Include("~/fonts/fonts.css")
                .Include("~/Content/jquery.fancybox.min.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/nice-select.css")
                .Include("~/Content/scroll.css")
                .Include("~/Content/style.css")
                .Include("~/Content/custom.css")
                );
        }
    }
}