using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Api.Seguranca
{
    //grant_type=password&username=yourusername&password=yourpassword no postman dentro da guia body 
        //escolhe raw
    public class AuthAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
              context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Orign",new[] {"*"});
            try
            {
                var username = context.UserName.Trim();
                var password = context.Password.Trim();

                if (username != "elir" || password != "1234")
                {
                    context.SetError("invalid-grant", "Usuário ou senha Inválido");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name,username));
                var roles = new List<string>();
                roles.Add("biblioteca");
                roles.Add("usuario");
                foreach (var role in roles) {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception)
            {

                context.SetError("invalid_grant","Falha no acesso");
            }
        }

        
    }
}