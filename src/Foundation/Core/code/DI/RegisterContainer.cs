using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Claro.Foundation.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Claro.Foundation.Core.DI
{
    public class RegisterContainer : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMediatorService, MediatorService>();
        }
    }
}