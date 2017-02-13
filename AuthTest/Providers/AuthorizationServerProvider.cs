using AuthTest.DbService;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AuthTest.Providers {
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try {
                //Obtem usuário da base de dados
                UserStoreService uss = new UserStoreService();
                var user = await uss.Authenticate(context.UserName, context.Password);

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.UserEmail));

                //TODO: Implementar roles para controle de acesso
                var rolesTechnicalNamesUser = new List<string>();

                //if (user.Roles != null) {
                //    rolesTechnicalNamesUser = user.Roles.Select(x => x.TechnicalName).ToList();

                //    foreach (var role in user.Roles)
                //        identity.AddClaim(new Claim(ClaimTypes.Role, role.TechnicalName));
                //}

                var principal = new GenericPrincipal(identity, rolesTechnicalNamesUser.ToArray());

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            } catch (Exception) {
                context.SetError("invalid_grant", "message");
            }
        }
    }
}