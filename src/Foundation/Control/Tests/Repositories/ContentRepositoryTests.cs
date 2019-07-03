using Claro.Foundation.Testing;
using FluentAssertions;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Foundation.Content.Tests.Repositories
{
    [TestClass]
    public class ContentRepositoryTests : TestBase<ContentRepositoryTestHarness>
    {
        [TestMethod]
        public void GetItem_ReturnItemObject()
        {
            //Arrange
            Object demo = new object();
            GetItemOptions opt = Substitute.For<GetItemOptions>();
            _testHarness.RequestContext.SitecoreService.GetItem(Arg.Any<GetItemOptions>()).Returns(demo);
            //Act
            var result = _testHarness.ContentRepository.GetItem(opt);
            //Assert
            result.Should().BeOfType<object>();
        }
        [TestMethod]
        public void GetItems_ReturnEmpty()
        {
            //Arrange
            IEnumerable<Object> items =null;
            GetItemsOptions opt = Substitute.For<GetItemsOptions>();
            _testHarness.RequestContext.SitecoreService.GetItems(Arg.Any<GetItemsOptions>()).Returns(items);
            //Act
            var result = _testHarness.ContentRepository.GetItems(opt);
            //Assert
            result.Should().BeNull();
        }
        [TestMethod]
        public void CreateItem_Success()
        {
            //Arrange
            Object demo = new object();
            CreateOptions opt = Substitute.For<CreateOptions>();
            _testHarness.RequestContext.SitecoreService.CreateItem(Arg.Any<CreateOptions>()).Returns(demo);
            //Act
            var result = _testHarness.ContentRepository.CreateItem(opt);
            //Assert
            result.Should().BeOfType<object>();
        }
        [TestMethod]
        public void SaveItem_Success()
        {
            //Arrange
            SaveOptions opt = Substitute.For<SaveOptions>();
            _testHarness.RequestContext.SitecoreService.SaveItem(Arg.Any<SaveOptions>());
            //Act
             _testHarness.ContentRepository.SaveItem(opt);
        }
        [TestMethod]
        public void MoveItem_Success()
        {
            //Arrange
            MoveByModelOptions opt = Substitute.For<MoveByModelOptions>();
            _testHarness.RequestContext.SitecoreService.MoveItem(Arg.Any<MoveByModelOptions>());
            //Act
            _testHarness.ContentRepository.MoveItem(opt);
        }
        [TestMethod]
        public void DeleteItem_Success()
        {
            //Arrange
            DeleteByModelOptions opt = Substitute.For<DeleteByModelOptions>();
            _testHarness.RequestContext.SitecoreService.DeleteItem(Arg.Any<DeleteByModelOptions>());
            //Act
            _testHarness.ContentRepository.DeleteItem(opt);
        }
    }
}
