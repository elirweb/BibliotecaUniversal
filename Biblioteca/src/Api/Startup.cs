using Api.Seguranca;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            HttpConfiguration config = new HttpConfiguration();

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