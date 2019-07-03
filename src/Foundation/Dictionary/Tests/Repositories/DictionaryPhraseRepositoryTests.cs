using Claro.Foundation.Dictionary.Models;
using Claro.Foundation.Testing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Claro.Foundation.Dictionary.Tests.Repositories
{
    [TestClass]
    public class DictionaryPhraseRepositoryTests:TestBase<DictionaryPhraseRepositoryTestHarness>
    {
        [TestMethod]
        public void Get_DictioryItemKeyValue()
        {
            //Arrange
            IDictionarySettings dictionarySettings = Substitute.For<IDictionarySettings>();
            IDictionaryEntry dictionaryEntry = Substitute.For<IDictionaryEntry>();
            _testHarness.SitecoreService.GetItem<IDictionarySettings>(Arg.Any<string>()).Returns(dictionarySettings);
            _testHarness.SitecoreService.GetItem<IDictionaryEntry>(Arg.Any<string>()).Returns(dictionaryEntry);

            //Act
            var result = _testHarness.DictionaryPhraseRepository.Get("/blog/LeaveComment", "Hello");
            //Arrange
            result.Should().Equals("Hello");
        }
    }
}
