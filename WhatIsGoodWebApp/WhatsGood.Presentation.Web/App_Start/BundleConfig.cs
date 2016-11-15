using System.Web.Optimization;

namespace WhatsGood.Presentation.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        "~/Scripts/modernizr-2.7.1.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.10.4.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular/angular.js",
                        "~/Scripts/angular/angular-route.js",
                        "~/Scripts/angular/angular-resource.js",
                        "~/Scripts/angular/ng-breadcrumbs.js",
                        "~/Scripts/angular/loading-bar.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js", 
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker/bootstrap-datetimepicker.js", 
                      "~/Scripts/ui-bootstrap-tpls-0.10.0.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/toastr.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/*.css"));
        }
    }
}
