using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Seguranca
{
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
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name,context.UserName));
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
            catch (Exception e)
            {
                context.SetError("invalid_grant","Falha no acesso" +e.Message);
            }
        }

        
    }
}