using System.Web;
using System.Web.Optimization;

namespace NewsTrack
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-2.1.4.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.min.js",
                      "~/Scripts/jquery.custom.js",
                      "~/Scripts/jquery.plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/history").Include(
                   "~/Scripts/history.js/history.adapter.jquery.js",
                   "~/Scripts/history.js/history.js",
                   "~/Scripts/history.js/json2.js"

           ));

            bundles.Add(new ScriptBundle("~/bundles/alertmessage").Include(
                     "~/Scripts/knockout-3.4.0.js",
                    "~/Scripts/ko/messages.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/stories").Include(
                     "~/Scripts/knockout-3.4.0.js",
                    "~/Scripts/jquery.timeago.js",
                    "~/Scripts/ko/story.js",
                    "~/Scripts/ko/messages.js",
                    "~/Scripts/ko/detail.js",
                    "~/Scripts/ko/general.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/base.css"));
        }
    }
}
