using Claro.Feature.Blog.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Feature.Blog.Tests.Services
{
    [TestClass]
    public class CommentServiceTests: TestBase<CommentServiceTestHarness>
    {
        [TestMethod]
        public void GetComments_ReturnEmptyItems()
        {
            //Arrange
            Item parentItem = null;
            IComment comment = Substitute.For<IComment>();
            _testHarness.ContentRepository.GetItem<Item>(Arg.Any<GetItemByIdOptions>()).Returns(parentItem);
            _testHarness.ContentRepository.GetItem<IComment>(Arg.Any<GetItemByItemOptions>()).Returns(comment);
            //Act
            var results = _testHarness.CommentService.GetComments("65466455-6456");
            //Assert
            results.Should().BeNullOrEmpty();

        }
        [TestMethod]
        public void GetComments_ReturnZeroCount()
        {
            //Arrange
            Item parentItem = null;
            int commentCount = 0;
            _testHarness.ContentRepository.GetItem<Item>(Arg.Any<GetItemByIdOptions>()).Returns(parentItem);
            //Act
            var results = _testHarness.CommentService.GetCommentsCount("65466455-6456");
            //Assert
            results.Should().Equals(commentCount);
        }
    }
}
