using Claro.Feature.Blog.Controllers;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Testing;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Feature.Blog.Tests.Controllers
{
    public class SearchControllerTestHarness: TestHarnessBase
    {
        ISearchContextManager _searchContextManager;
        public ISearchContextManager SearchContextManager
        {
            get
            {
                if (_searchContextManager == null)
                    _searchContextManager = Substitute.For<ISearchContextManager>();
                return _searchContextManager;
            }
        }
        public readonly SearchController _searchController;
        public SearchControllerTestHarness()
        {
            _fixture = new Fixture();
            _searchController = new SearchController(SearchContextManager);
        }
    }
}
