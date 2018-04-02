using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Web
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

            container.Options.DefaultLifestyle = new WebRequestLifestyle();


            //BOUNDED CONTEXTS

            Biblioteca.Core.Infra.IoC.Bootstrap.Register(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}