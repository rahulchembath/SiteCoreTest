using Claro.Feature.Blog.Models;
using Claro.Foundation.Settings.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Feature.Blog.Tests.Services
{
    [TestClass]
    public class QuoteServiceTests : TestBase<QuoteServiceTestHarness>
    {
        private IItemPathSettings itemPathSettings;
        public QuoteServiceTests()
        {
            itemPathSettings = Substitute.For<IItemPathSettings>();
        }

        [TestMethod]
        public void GetQuotes_GivenLevel_ReturnsNull()
        {
            //Arrange
            var quoteFolder = Substitute.For<IQuoteFolder>();
            IEnumerable<IQuote> quote = Substitute.For<IEnumerable<IQuote>>();

            _testHarness.ContextRepository.GetRootItem<IItemPathSettings>().Returns(itemPathSettings);
            _testHarness.ContentRepository.GetItem<IQuoteFolder>(It.IsAny<GetItemOptions>()).Returns(quoteFolder);
            quoteFolder.Quotes.Returns(quote);

            //Act
            var result = _testHarness.QuoteService.GetQuotes(1);

            //Assert
            result.Should().BeNull();
        }
    }
}
