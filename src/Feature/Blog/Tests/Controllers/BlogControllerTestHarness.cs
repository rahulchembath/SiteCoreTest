using Claro.Feature.Blog.Controllers;
using Claro.Feature.Blog.Interface;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Testing;
using NSubstitute;
using Ploeh.AutoFixture;
using System.Web.Mvc;

namespace Claro.Feature.Blog.Tests.Controllers
{
    public class BlogControllerTestHarness : TestHarnessBase
    {

        IRenderingRepository _renderingRepository;
        IQuoteService _quoteService;
       // IGlassHtml _glassHtml;
        ISearchContextManager _searchContextManager;
        IConverter<IBlog, BlogDetailViewModel> _blogDetailViewModelConverter;
        IConverter<IBlog, BlogViewModel> _blogViewModelConverter;

        public IRenderingRepository RenderingRepository
        {
            get
            {
                if (_renderingRepository == null)
                    _renderingRepository = Substitute.For<IRenderingRepository>();
                return _renderingRepository;
            }
        }



     

        public IQuoteService QuoteService
        {
            get
            {
                if (_quoteService == null)
                    _quoteService = Substitute.For<IQuoteService>();
                return _quoteService;
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
        public ISearchContextManager SearchContextManager
        {
            get
            {
                if (_searchContextManager == null)
                    _searchContextManager = Substitute.For<ISearchContextManager>();
                return _searchContextManager;
            }
        }
        public IConverter<IBlog, BlogDetailViewModel> BlogDetailViewModelConverter
        {
            get
            {
                if (_blogDetailViewModelConverter == null)
                    _blogDetailViewModelConverter = Substitute.For<IConverter<IBlog, BlogDetailViewModel>>();
                return _blogDetailViewModelConverter;
            }
        }
        public IConverter<IBlog, BlogViewModel> BlogViewModelConverter
        {
            get
            {
                if (_blogViewModelConverter == null)
                    _blogViewModelConverter = Substitute.For<IConverter<IBlog, BlogViewModel>>();
                return _blogViewModelConverter;
            }
        }
        public readonly BlogController _BlogController;

        public BlogControllerTestHarness()
        {
            _fixture = new Fixture();
            _fixture.Customize<ControllerContext>(ob => ob.OmitAutoProperties().With(cc => cc.HttpContext));
            _BlogController = new BlogController(RenderingRepository, QuoteService, SearchContextManager,BlogDetailViewModelConverter,BlogViewModelConverter);
        }
    }
}
