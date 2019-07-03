using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Testing;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Feature.Blog.Tests.Services
{
    public class CommentServiceTestHarness: TestHarnessBase
    {
       IContentRepository _contentRepository;
    IContextRepository _contextRepository;
        public IContentRepository ContentRepository
        {
            get
            {
                if (_contentRepository == null)
                    _contentRepository = Substitute.For<IContentRepository>();
                return _contentRepository;
            }
        }
        public IContextRepository ContextRepository
        {
            get
            {
                if (_contextRepository == null)
                    _contextRepository = Substitute.For<IContextRepository>();
                return _contextRepository;
            }
        }
        public readonly ICommentService CommentService;


        public CommentServiceTestHarness()
        {
            _fixture = new Fixture();
            CommentService = new CommentService(ContentRepository,ContextRepository);
        }
    }
}
