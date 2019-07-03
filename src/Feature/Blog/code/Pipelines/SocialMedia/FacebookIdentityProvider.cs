using System.Threading.Tasks;
using Owin;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Pipelines.IdentityProviders;
using Sitecore.Owin.Authentication.Services;
using Sitecore.Owin.Authentication.Extensions;

namespace Claro.Feature.Blog.Pipelines.SocialMedia
{
    public class FacebookIdentityProvider : IdentityProvidersProcessor
    {
        protected override string IdentityProviderName => "Facebook";
        private readonly string AppId = Sitecore.Configuration.Settings.GetSetting("FacebookAppId", "299745210740921");//"675721606219589";
        private readonly string AppSecret = Sitecore.Configuration.Settings.GetSetting("FacebookAppSecret", "1983552ac47c574e9927fa2231a62c74");//"b3b32e0f0bdc54ab2afd3634cc77e727";

        protected IdentityProvider IdentityProvider { get; set; }

        public FacebookIdentityProvider(FederatedAuthenticationConfiguration federatedAuthenticationConfiguration, Microsoft.Owin.Infrastructure.ICookieManager cookieManager, Sitecore.Abstractions.BaseSettings settings)
            : base(federatedAuthenticationConfiguration, cookieManager, settings)
        {
        }

        protected override void ProcessCore(IdentityProvidersArgs args)
        {
           
            Assert.ArgumentNotNull(args, "args");
            IdentityProvider = this.GetIdentityProvider();

            var provider = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationProvider
            {
                OnAuthenticated = (context) =>
                {
                    //map claims
                    context.Identity.ApplyClaimsTransformations(new TransformationContext(this.FederatedAuthenticationConfiguration, IdentityProvider));
                    return Task.CompletedTask;
                },
                OnReturnEndpoint = (context) =>
                {
                    return Task.CompletedTask;
                },
            };

            var fbAuthOptions = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            {
                AppId = AppId,
                AppSecret = AppSecret,
                Provider = provider,
                AuthenticationType = IdentityProvider.Name
            };

            args.App.UseFacebookAuthentication(fbAuthOptions);
        }
    }
}