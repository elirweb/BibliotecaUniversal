using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    public class Bootstrapper
    {
        public static Container container { get; set; }

        public static void Inicializar()
        {
           
                ConfigurarContainer();
          
        }

        private static void ConfigurarContainer()
        {
            container = new Container();
            
            Biblioteca.Core.Infra.IoC.Bootstrap.Register(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

                        


        }


    }
}