using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Security.OAuth;
using censusApp.BLL;

[assembly: OwinStartup(typeof(censusApp.API.Startup))]

namespace censusApp.API
{
    /// <summary>
    /// Class Startup configures the startup of the application 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations the specified application 
        /// </summary>
        /// <param name="app">A standard implementation of IAppBuilder</param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
