using Api.Seguranca;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;
using Usuario.Application.Interfaces;

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            var container = new Container();
            Biblioteca.Core.Infra.IoC.Bootstrap.Register(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            HttpConfiguration config = new HttpConfiguration() {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
        };
            container.Verify();

            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            // package
            /* 
            nugget
            Install-Package Microsoft.AspNet.WebApi.Owin
            Install-Package Microsoft.Owin.Host.SystemWeb
            Install-Package Microsoft.Owin.Security.OAuth
            Install-Package Microsoft.Owin.Cors
 

             */

        }


        public void ConfigureOAuth(IAppBuilder app) {

            OAuthAuthorizationServerOptions oAuthServer = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthAuthorizationServerProvider()
                
            };

            app.UseOAuthAuthorizationServer(oAuthServer);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}