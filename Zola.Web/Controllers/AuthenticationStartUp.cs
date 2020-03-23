using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Owin;

//[assembly: OwinStartup(typeof(Zola.Web.Controllers.AuthenticationStartUp))]

namespace Zola.Web.Controllers
{
    public class AuthenticationStartUp : OAuthAuthorizationServerProvider
   {
   //     PM> Install-Package Microsoft.AspNet.Identity.Owin
   //PM> Install-Package Microsoft.Owin.Host.SystemWeb
   //         PM> Install-Package Microsoft.AspNet.Identity.EntityFramework
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if(context.UserName =="admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "akanksha"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "akanksha1"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect.");
            }
        }
    }
}
