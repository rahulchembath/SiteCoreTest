using Claro.Foundation.Indexing.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Claro.Foundation.Indexing.DI
{
    public class IndexInstaller : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISearchService, SearchService>();
        }
    }
}