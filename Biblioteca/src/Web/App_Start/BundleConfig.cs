using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new StyleBundle("~/Content/css").
                Include("~/Content/css/mp-theme.min.css"
                //"~/Content/css/custom.css",
                //"~/Content/css/layout.css",
                //"~/Content/css/meuspedidos.css"
                //
                ));

            bundles.Add(new StyleBundle("~/Content/css/main").Include("~/Content/css/layout.css"));

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
                "~/Scripts/js/sb-admin-charts.min.js",
                "~/Scripts/js/util.js"
                ));

            
           

            
             bundles.Add(new ScriptBundle("~/Scripts/angular")
                 .Include("~/Scripts/angular/angular.min.js",
                 "~/Scripts/angular/angular-route.js"
                 , "~/Scripts/angular/module/modulo.js",
                    "~/Scripts/angular/value/config.js",
                    "~/Scripts/angular/value/route.js",
                 "~/Scripts/angular/service/AuthenticaService.js",
                 "~/Scripts/angular/service/AuthenticaServiceAdm.js",
                 "~/Scripts/angular/service/biblioteca-service.js",
                 "~/Scripts/angular/service/UsuarioService.js",
                 "~/Scripts/angular/service/TokenService.js",
                 "~/Scripts/angular/controller/AuthCtrl.js",
                 "~/Scripts/angular/controller/AuthAdmCtrl.js",
                 "~/Scripts/angular/controller/MenuCtrl.js",
                 "~/Scripts/angular/controller/BibliotecaCtrl.js",
                 "~/Scripts/angular/controller/Livroctrl.js",
                    "~/Scripts/angular/controller/UsuarioCtrl.js"
                 ));

              
        }
    }
}
