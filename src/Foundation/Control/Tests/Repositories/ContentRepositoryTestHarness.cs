using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Testing;
using Glass.Mapper.Sc.Web;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Foundation.Content.Tests.Repositories
{
    public class ContentRepositoryTestHarness : TestHarnessBase
    {
        IRequestContext _requestContext;
        public IRequestContext RequestContext
        {
            get
            {
                if (_requestContext == null)
                    _requestContext = Substitute.For<IRequestContext>();
                return _requestContext;
            }
        }
        public readonly IContentRepository ContentRepository;
        public ContentRepositoryTestHarness()
        {
            _fixture = new Fixture();
            ContentRepository = new ContentRepository(RequestContext);
        }
    }
}
