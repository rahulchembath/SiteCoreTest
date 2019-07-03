using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Indexing.Services;
using Claro.Foundation.Testing;
using Glass.Mapper.Sc;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Feature.Blog.Tests.Services
{
    public class SearchContextManagerTestHarness : TestHarnessBase
    {
        IContextRepository _contextRepository;
        IContentRepository _contentRepository;
        ISearchService _searchService;
        IConverter<IBlog, BlogViewModel> _blogViewModelConverter;
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
        public ISearchService SearchService
        {
            get
            {
                if (_searchService == null)
                    _searchService = Substitute.For<ISearchService>();
                return _searchService;
            }
        }
        public IConverter<IBlog, BlogViewModel> BlogViewModelConverter
        {
            get
            {
                if(_blogViewModelConverter ==null)
                    _blogViewModelConverter= Substitute.For<IConverter<IBlog, BlogViewModel>>();
                return _blogViewModelConverter;
            }
        }
        //public IGlassHtml GlassHtml
        //{
        //    get
        //    {
        //        if (_glassHtml == null)
        //            _glassHtml = Substitute.For<IGlassHtml>();
        //        return _glassHtml;
        //    }
        //}
        //public ICommentService CommentService
        //{
        //    get
        //    {
        //        if (_commentService == null)
        //            _commentService = Substitute.For<ICommentService>();
        //        return _commentService;
        //    }
        //}
        public readonly ISearchContextManager SearchContextManager;


        public SearchContextManagerTestHarness()
        {
            _fixture = new Fixture();
            SearchContextManager = new SearchContextManager(ContextRepository, ContentRepository,SearchService, BlogViewModelConverter);
        }

    }
}
