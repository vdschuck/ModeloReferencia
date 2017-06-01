using System.Web;
using System.Web.Optimization;

namespace ModeloDeReferencia.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",                      
                      "~/Content/ngDialog.css",
                      "~/Content/ngDialog-Custom.css",
                      "~/Content/ngDialog-theme-default.css",
                      "~/Content/font-awesome.min.css",                       
                      "~/Content/select.min.css"));  

            bundles.Add(new ScriptBundle("~/bundles/angular")
                        .Include(   "~/Scripts/angular.min.js", 
                                    "~/Scripts/angular-route.js",
                                    "~/Scripts/ngDialog.js",                                     
                                    "~/Scripts/angular-animate.min.js",
                                    "~/Scripts/angular-messages.min.js",
                                    "~/Scripts/angular-resource.min.js",
                                    "~/Scripts/jquery-ui.js",
                                    "~/Scripts/angular-ui/ui-bootstrap.js",
                                    "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                                    "~/Scripts/angular-mocks.js",
                                    "~/Scripts/angular-sanitize.min.js",
                                    "~/Scripts/bootstrap-datepicker.min.js",
                                    "~/Scripts/moment.js",
                                    "~/Scripts/moment-with-locales.js",
                                    "~/Scripts/bootstrap-datetimepicker.min.js",
                                    "~/Angular/app.js",
                                    "~/Angular/config.js",
                                    "~/Scripts/select.min.js",
                                    "~/Scripts/dirPagination.js"    )
                        .IncludeDirectory("~/Angular/Services", "*.js")
                        .IncludeDirectory("~/Angular/Factories", "*.js")
                        .IncludeDirectory("~/Angular/Directives", "*.js")
                        .IncludeDirectory("~/Angular/Controllers", "*.js")
            );
        }
    }
}
