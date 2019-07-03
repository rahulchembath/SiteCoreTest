using Claro.Feature.Blog.Converter;
using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Claro.Feature.Blog.DI
{
    public class RegisterContainer : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IQuoteService, QuoteService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();
            serviceCollection.AddTransient<ISearchContextManager, SearchContextManager>();
            serviceCollection.AddTransient<IConverter<IBlog, BlogViewModel>, BlogViewModelConverter>();
            serviceCollection.AddTransient<IConverter<IBlog, BlogDetailViewModel>, BlogDetailsViewModelConverter>();
        }
    }
}