using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace SageAPI
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      string appSetting = ConfigurationManager.AppSettings["OktaAuth"];
      ConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(appSetting + "/.well-known/openid-configuration", (IConfigurationRetriever<OpenIdConnectConfiguration>) new OpenIdConnectConfigurationRetriever(), (IDocumentRetriever) new HttpDocumentRetriever());
      OpenIdConnectConfiguration discoveryDocument = Task.Run<OpenIdConnectConfiguration>((Func<Task<OpenIdConnectConfiguration>>) (() => configurationManager.GetConfigurationAsync())).GetAwaiter().GetResult();
      IAppBuilder app1 = app;
      JwtBearerAuthenticationOptions options = new JwtBearerAuthenticationOptions();
      options.AuthenticationMode = AuthenticationMode.Active;
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidAudience = "api://default",
        ValidIssuer = appSetting,
        IssuerSigningKeyResolver = (IssuerSigningKeyResolver) ((token, securityToken, identifier, parameters) => (IEnumerable<SecurityKey>) discoveryDocument.SigningKeys)
      };
      app1.UseJwtBearerAuthentication(options);
      HttpConfiguration configuration = new HttpConfiguration();
      configuration.MapHttpAttributeRoutes();
      configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", (object) new
      {
        id = RouteParameter.Optional
      });
      app.UseWebApi(configuration);
    }
  }
}
