using System.Threading.Tasks;
using Owin;
using Owin.Security.Providers.Google;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Extensions;
using Sitecore.Owin.Authentication.Pipelines.IdentityProviders;
using Sitecore.Owin.Authentication.Services;

namespace Claro.Feature.Blog.Pipelines.SocialMedia
{
    public class GoogleIdentityProvider : IdentityProvidersProcessor
    {
        protected override string IdentityProviderName => "Google";
        private readonly string ClientId = Sitecore.Configuration.Settings.GetSetting("GoogleClientId", "444533759211-aa3u1d8771j6uh1574n77eftt1a6cuc0.apps.googleusercontent.com");// "466067690132-p5v4i9tomjkkuqfedvohii4n207kgult.apps.googleusercontent.com";
        private readonly string ClientSecret = Sitecore.Configuration.Settings.GetSetting("GoogleClientSecret", "UvQnU-rDa2nPNdEuS2wQJ0Le");//"mClfMB3oYMqKNS7pgpNtiq9e";

        protected IdentityProvider IdentityProvider { get; set; }

        public GoogleIdentityProvider(FederatedAuthenticationConfiguration federatedAuthenticationConfiguration, Microsoft.Owin.Infrastructure.ICookieManager cookieManager, Sitecore.Abstractions.BaseSettings settings)
            : base(federatedAuthenticationConfiguration, cookieManager, settings)
        {
        }

        protected override void ProcessCore(IdentityProvidersArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            IdentityProvider = this.GetIdentityProvider();

            var provider = new Owin.Security.Providers.Google.Provider.GoogleAuthenticationProvider
            {
                OnAuthenticated = (context) =>
                {
                    //map claims
                    context.Identity.ApplyClaimsTransformations(new TransformationContext(this.FederatedAuthenticationConfiguration, IdentityProvider));
                    return Task.CompletedTask;
                }
            };

            var googleAuthOptions = new GoogleAuthenticationOptions
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Provider = provider,
                AuthenticationType = IdentityProvider.Name
            };

            args.App.UseGoogleAuthentication(googleAuthOptions);
        }
    }
}