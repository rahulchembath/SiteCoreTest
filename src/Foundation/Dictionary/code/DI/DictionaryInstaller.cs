using Claro.Foundation.Dictionary.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Claro.Foundation.Dictionary.DI
{
    public class DictionaryInstaller : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDictionaryPhraseRepository, DictionaryPhraseRepository>();
        }
    }
}