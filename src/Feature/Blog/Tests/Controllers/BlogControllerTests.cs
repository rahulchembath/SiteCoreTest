using Claro.Feature.Blog.Controllers;
using Claro.Feature.Blog.Models;
using Claro.Feature.Blog.Services;
using Claro.Foundation.Indexing.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Claro.Feature.Blog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTests : TestBase<BlogControllerTestHarness>
    {
        [TestMethod]

        public void FeatureArticle_Given_ReturnFeatureBlogToView()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<ControllerContext>(c => c.Without(x => x.DisplayMode));
           
            List<BlogViewModel> blogViewModelDummy = fixture.CreateMany<BlogViewModel>().ToList();
            ISearchContextManager df = Substitute.For<ISearchContextManager>();
            var mockScMrg = fixture.Freeze<Mock<ISearchContextManager>>();
            mockScMrg.Setup(r => r.GetBlogs(Arg.Any<SearchQuery>(), Arg.Any<bool>())).Returns(blogViewModelDummy);
            BlogController blgController = fixture.Freeze<BlogController>();

            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
               ControllerContext contextItem =
            new ControllerContext(
            new RequestContext(), blgController);
            blgController.ControllerContext = contextItem;

            //Act
            var result = blgController.FeaturedArticle() as ViewResult;
            //assert
            result.ViewName.Should().Be(Constants.FeaturedArticle);

        }
        [TestMethod]
        public void FeatureArticle_Given_ReturnEmptyBlogToView()
        {
            var fixture = new Fixture();
            List<BlogViewModel> blogViewModelDummy = null;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.FeaturedArticle() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.FeaturedArticle);
        }
        [TestMethod]
        public void BlogList_Given_ReturnBlogsToView()
        {
            var fixture = new Fixture();
            //fixture.Customize<ControllerContext>(ob => ob.OmitAutoProperties().With(cc => cc.HttpContext));
            var itemid = ID.NewID;
            var definition = new ItemDefinition(itemid, string.Empty, ID.Null, ID.Null);
            var data = new ItemData(definition, Language.Current, Sitecore.Data.Version.First, new FieldList());
            Database db = Substitute.For<Database>();
            Item item = Substitute.For<Item>(itemid, data, db);
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            _testHarness.RenderingRepository.GetPageContextItem<Item>().Returns(item);
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.BlogList() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.BlogList);
        }
        [TestMethod]
        public void BlogList_Given_ReturnEmptyBlogsToView()
        {
            var fixture = new Fixture();
            fixture.Customize<ControllerContext>(ob => ob.OmitAutoProperties().With(cc => cc.HttpContext));
            var itemid = ID.NewID;
            var definition = new ItemDefinition(itemid, string.Empty, ID.Null, ID.Null);
            var data = new ItemData(definition, Language.Current, Sitecore.Data.Version.First, new FieldList());
            Database db = Substitute.For<Database>();
            Item item = Substitute.For<Item>(itemid, data, db);
            List<BlogViewModel> blogViewModelDummy = null;
            _testHarness.RenderingRepository.GetPageContextItem<Item>().Returns(item);
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.BlogList() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.BlogList);
        }
        [TestMethod]
        public void GetBlogs_Given_ReturnBlogsToView()
        {
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.GetBlogs(0, string.Empty, string.Empty) as PartialViewResult;

            //assert
            result.ViewName.Should().Be(Constants.BlogPartialPage);
        }
        [TestMethod]
        public void GetBlogs_Given_ReturnEmptyBlogToView()
        {
            List<BlogViewModel> blogViewModelDummy = null;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.GetBlogs(0, string.Empty, string.Empty) as PartialViewResult;

            //assert
            result.ViewName.Should().Be(Constants.BlogPartialPage);
        }
        [TestMethod]
        public void BlogDetails_Given_ReturnBlogstoView()
        {
            //Arrange
            var fixture = new Fixture();
            var response = fixture.Build<BlogListViewModel>().Create();
            IBlog blogDummy = Substitute.For<IBlog>();

            _testHarness.RenderingRepository.GetPageContextItem<IBlog>().Returns(blogDummy);

            //Act
            var result = _testHarness._BlogController.BlogDetails() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.BlogDetailsViewName);
        }
        [TestMethod]
        public void RelatedBlog_Given_ReturnBlogToView()
        {
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.RelatedBlog() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.RelatedBlogViewName);
        }
        [TestMethod]
        public void RelatedBlog_Given_ReturnEmptyBlogToView()
        {
            List<BlogViewModel> blogViewModelDummy = null;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.RelatedBlog() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.RelatedBlogViewName);
        }
        [TestMethod]
        public void OtherInsight_Given_ReturnBlogsToView()
        {
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.OtherInsight() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.OtherInsightViewName);
        }
        [TestMethod]
        public void OtherInsight_Given_ReturnEmptyBlogToView()
        {
            List<BlogViewModel> blogViewModelDummy = null;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, Category = string.Empty };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);

            //Act
            var result = _testHarness._BlogController.OtherInsight() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.OtherInsightViewName);
        }
    }
}
