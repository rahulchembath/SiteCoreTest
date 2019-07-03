using Claro.Foundation.Indexing.Models;

namespace Claro.Foundation.Indexing.Services
{
    public interface ISearchService
    {
        ISearchResults SearchBlogs(IQuery query);
    }
}
