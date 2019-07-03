using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Identity;
using System;

namespace Claro.Feature.Blog.Services
{
    public class CustomExternalUserBuilder : Sitecore.Owin.Authentication.Services.DefaultExternalUserBuilder
    {
        public CustomExternalUserBuilder(bool isPersistentUser)
            : base(isPersistentUser)
        {
        }

        public CustomExternalUserBuilder(string isPersistentUser)
            : base(bool.Parse(isPersistentUser))
        {
        }

        protected override string CreateUniqueUserName(UserManager<ApplicationUser> userManager, ExternalLoginInfo externalLoginInfo)
        {
            Assert.ArgumentNotNull(userManager, "userManager");
            Assert.ArgumentNotNull(externalLoginInfo, "externalLoginInfo");

            IdentityProvider identityProvider = this.FederatedAuthenticationConfiguration.GetIdentityProvider(externalLoginInfo.ExternalIdentity);
            if (identityProvider == null)
                throw new InvalidOperationException("Unable to retrieve identity provider for given identity");
            return externalLoginInfo.DefaultUserName;
        }
    }
}