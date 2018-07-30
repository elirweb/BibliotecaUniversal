using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/vendor/datatables/dataTables.bootstrap4.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").
                Include("~/Content/css/sb-admin.css"));

            bundles.Add(new ScriptBundle("~/Content/vendor/jquery").
                Include("~/Content/vendor/jquery/jquery.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Content/vendor/bootstrap").
                Include("~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"));


            bundles.Add(new ScriptBundle("~/Content/vendor/jquery-easing").
               Include("~/Content/vendor/jquery-easing/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/Content/vendor/chart.js").
               Include("~/Content/vendor/chart.js/Chart.min.js"));

            bundles.Add(new ScriptBundle("~/Content/vendor/datatables").
            Include("~/Content/vendor/datatables/jquery.dataTables.js", 
            "~/Content/vendor/datatables/dataTables.bootstrap4.js"));
            
            
            bundles.Add(new ScriptBundle("~/Scripts/js").
                Include("~/Scripts/js/sb-admin.min.js", 
                "~/Scripts/js/sb-admin-datatables.min.js",
                "~/Scripts/js/sb-admin-charts.min.js"));

            
           

            
             bundles.Add(new ScriptBundle("~/Scripts/angular")
                 .Include("~/Scripts/angular/angular.min.js"
                 , "~/Scripts/angular/module/modulo.js",
                    "~/Scripts/angular/value/config.js",
                 "~/Scripts/angular/service/AuthenticaService.js",
                 "~/Scripts/angular/service/AuthenticaServiceAdm.js",
                 "~/Scripts/angular/service/biblioteca-service.js",
                 "~/Scripts/angular/controller/AuthCtrl.js",
                 "~/Scripts/angular/controller/AuthCtrlAdm.js",
                 "~/Scripts/angular/controller/biblioteca.js"
                 ));

              
        }
    }
}
