using Claro.Feature.Blog.Models;
using Claro.Foundation.Indexing.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Claro.Feature.Blog.Tests.Controllers
{
    [TestClass]
    public class SearchControllerTests : TestBase<SearchControllerTestHarness>
    {
        [TestMethod]
        public void GlobalSearch_Given_ReturnSearchContextToView()
        {
            //Arrange
            SearchContext seachContext = Substitute.For<SearchContext>();
            _testHarness.SearchContextManager.Get().Returns(seachContext);
            //Act
            var result = _testHarness._searchController.GlobalSearch() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.GlobalSearchViewName);

        }
        [TestMethod]
        public void SearchHeader_Given_ReturnSearchContextToView()
        {
            //Arrange
            SearchContext seachContext = Substitute.For<SearchContext>();
            _testHarness.SearchContextManager.Get().Returns(seachContext);
            //Act
            var result = _testHarness._searchController.SearchHeader() as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SearchHeaderViewName);
        }
        [TestMethod]
        public void SearchResults_Given_ReturnSearchItemToView()
        {
            //Arrange
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            string query = "Macro";
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, SearchText = query };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);
            //Act
            var result = _testHarness._searchController.SearchResults(query) as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SearchResultsViewName);
        }


        [TestMethod]
        public void SearchResults_Given_ReturnNoItemToView()
        {
            //Arrange
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            string query = "Masfsdffsdfsdfcro";
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, SearchText = query };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);
            //Act
            var result = _testHarness._searchController.SearchResults(query) as ViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SearchResultsViewName);
        }
        [TestMethod]
        public void SearchBlogs_Given_ReturnBlogsToView()
        {
            //Arrange
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            string query = "Macro";
            int pageNo = 0;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, SearchText = query };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);
            //Act
            var result = _testHarness._searchController.SearchBlogs(pageNo,query) as PartialViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SearchBlogResultsViewName);
        }
        [TestMethod]
        public void SearchBlogs_Given_ReturnEmptyToView()
        {
            //Arrange
            List<BlogViewModel> blogViewModelDummy = Substitute.For<List<BlogViewModel>>();
            string query = "sddfdsdffdf";
            int pageNo = 0;
            var searchQuery = new SearchQuery { NoOfResults = Constants.PageSize_One, Page = Constants.IntialPageNo, SearchText = query };
            _testHarness.SearchContextManager.GetBlogs(searchQuery, true).Returns(blogViewModelDummy);
            //Act
            var result = _testHarness._searchController.SearchBlogs(pageNo, query) as PartialViewResult;

            //assert
            result.ViewName.Should().Be(Constants.SearchBlogResultsViewName);
        }
    }
}
