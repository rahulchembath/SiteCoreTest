using Claro.Feature.Blog.Controllers;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Dictionary.Repositories;
using Claro.Foundation.Testing;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Feature.Blog.Tests.Controllers
{
    public class CommentControllerTestHarness : TestHarnessBase
    {
        IRenderingRepository _renderingRepository;
        ICommentService _commentService;
        IDictionaryPhraseRepository _dictionaryPhraseRepository;


        public IRenderingRepository RenderingRepository
        {
            get
            {
                if (_renderingRepository == null)
                    _renderingRepository = Substitute.For<IRenderingRepository>();
                return _renderingRepository;
            }
        }
        public ICommentService CommentService
        {
            get
            {
                if (_commentService == null)
                    _commentService = Substitute.For<ICommentService>();
                return _commentService;
            }
        }
        public IDictionaryPhraseRepository DictionaryPhraseRepository
        {
            get
            {
                if (_dictionaryPhraseRepository == null)
                    _dictionaryPhraseRepository = Substitute.For<IDictionaryPhraseRepository>();
                return _dictionaryPhraseRepository;
            }
        }
        public readonly CommentController _CommentController;
        public CommentControllerTestHarness()
        {
            _fixture = new Fixture();
            _CommentController = new CommentController(RenderingRepository, CommentService, DictionaryPhraseRepository);
        }
    }
}
