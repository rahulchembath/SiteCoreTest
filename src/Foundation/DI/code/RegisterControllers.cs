using Claro.Foundation.DI.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
namespace Claro.Foundation.DI
{
    public class RegisterControllers : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllers(
                "Claro.Feature.*");
        }
    }
}
