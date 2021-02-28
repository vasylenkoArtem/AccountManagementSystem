using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;

using IdentityServer3.AccessTokenValidation;
using System;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(AMS.API.Startup))]

namespace AMS.API
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44366/"
            });

        }
    }
}
