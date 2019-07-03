using Claro.Feature.Blog.Models;
using Claro.Foundation.Indexing.Models;
using System.Collections.Generic;

namespace Claro.Feature.Blog.Services
{
    public interface ISearchContextManager
    {
        SearchContext Get();
        List<BlogViewModel> GetBlogs(IQuery searchQuery,bool isFeatureArticle = false);
    }
}
