using Claro.Feature.Blog.Models;

namespace Claro.Feature.Blog.Services
{
    public interface IQuoteService
    {
        IQuote GetQuotes(int level);
    }
}
