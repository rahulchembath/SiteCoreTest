using Owin.Security.Providers.LinkedIn;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Extensions;
using Sitecore.Owin.Authentication.Pipelines.IdentityProviders;
using Sitecore.Owin.Authentication.Services;
using System.Threading.Tasks;

namespace Claro.Feature.Blog.Pipelines.SocialMedia
{
    public class LinkedInIdentityProvider : IdentityProvidersProcessor
    {
        protected override string IdentityProviderName => "Linkedin";
        private readonly string ClientId = Sitecore.Configuration.Settings.GetSetting("LinkedInClientId", "772m0broqebf32");// "813emmpbk8jrml";
        private readonly string ClientSecret = Sitecore.Configuration.Settings.GetSetting("LinkedInClientSecret", "Hd7OAJUZ6wtaTF1Y");// "GUOS2msQkKtZ4Czz";

        protected IdentityProvider IdentityProvider { get; set; }

        public LinkedInIdentityProvider(FederatedAuthenticationConfiguration federatedAuthenticationConfiguration, Microsoft.Owin.Infrastructure.ICookieManager cookieManager, Sitecore.Abstractions.BaseSettings settings)
            : base(federatedAuthenticationConfiguration, cookieManager, settings)
        {
        }

        protected override void ProcessCore(IdentityProvidersArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            IdentityProvider = this.GetIdentityProvider();

            var provider = new Owin.Security.Providers.LinkedIn.LinkedInAuthenticationProvider
            {
                OnAuthenticated = (context) =>
                {
                    //map claims
                    context.Identity.ApplyClaimsTransformations(new TransformationContext(this.FederatedAuthenticationConfiguration, IdentityProvider));
                    return Task.CompletedTask;
                }
            };

            var LinkedinAuthOptions = new Owin.Security.Providers.LinkedIn.LinkedInAuthenticationOptions
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Provider = provider,
                AuthenticationType = IdentityProvider.Name
            };

            args.App.UseLinkedInAuthentication(LinkedinAuthOptions);
        }
    }
}