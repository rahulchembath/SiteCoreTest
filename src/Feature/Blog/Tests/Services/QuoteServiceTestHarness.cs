using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Testing;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Feature.Blog.Tests.Services
{
    public class QuoteServiceTestHarness : TestHarnessBase
    {
        private IContentRepository _contentRepository;
        private IContextRepository _contextRepository;

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

        public readonly IQuoteService QuoteService;


        public QuoteServiceTestHarness()
        {
            _fixture = new Fixture();
            QuoteService = new QuoteService(ContentRepository, ContextRepository);
        }

    }
}