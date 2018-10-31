using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
  
        protected void Application_Start()
        {
          
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // dar performance na aplicação MVC 
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            if (WebConfigurationManager.ConnectionStrings["Contexto"].ToString().Equals(@"Data Source=LAPTOP-IGEISN1L\SQLEXPRESS;Initial Catalog=BibliotecaUnirversal;User ID=sa;password=elirweb"))
            {
               
                var nova_string = Biblioteca.Core.Domain.Util.Criptografia.Encriptar(WebConfigurationManager.ConnectionStrings["Contexto"].ToString());

                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.ConnectionStrings.ConnectionStrings["Contexto"].ConnectionString = nova_string;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("Contexto");
            }

            Bootstrapper.Inicializar();

        }
    }
}
