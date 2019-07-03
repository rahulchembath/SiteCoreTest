using Claro.Feature.Blog.Models;
using Claro.Foundation.Indexing.Models;
using Claro.Foundation.Settings.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sitecore.Data.Items;

namespace Claro.Feature.Blog.Tests.Services
{
    [TestClass]
    public class SearchContextManagerTests : TestBase<SearchContextManagerTestHarness>
    {
        [TestMethod]
        public void Get_GivenReturnSearchContext()
        {
            //arrange
            Item item = null;
            ISearchSettings searchSettings = Substitute.For<ISearchSettings>();
            _testHarness.ContextRepository.GetRootItem<ISearchSettings>().Returns(searchSettings);
            _testHarness.ContentRepository.GetItem<Item>(Arg.Any<GetItemByPathOptions>()).Returns(item);
            //act
            var result = _testHarness.SearchContextManager.Get();
            //assert
            result.Should().BeOfType<SearchContext>();

        }
        [TestMethod]
        public void GetBlogs_ReturnEmptyItems()
        {
            //Arrange
            IQuery query= Substitute.For<IQuery>();
            IBlog blog = Substitute.For<IBlog>();
            ISearchResults searchResults = Substitute.For<ISearchResults>();
            _testHarness.SearchService.SearchBlogs(query);
            _testHarness.ContentRepository.GetItem<IBlog>(Arg.Any<GetItemByIdOptions>()).Returns(blog);

            //Act
            var result = _testHarness.SearchContextManager.GetBlogs(query);
            //Assert
            result.Should().AllBeOfType<BlogViewModel>();
        }

    }
}
