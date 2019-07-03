using Claro.Foundation.Dictionary.Repositories;
using Claro.Foundation.Testing;
using Glass.Mapper.Sc;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Claro.Foundation.Dictionary.Tests.Repositories
{
    public class DictionaryPhraseRepositoryTestHarness : TestHarnessBase
    {
        ISitecoreService _sitecoreService;
        public ISitecoreService SitecoreService
        {
            get
            {
                if (_sitecoreService == null)
                    _sitecoreService = Substitute.For<ISitecoreService>();
                return _sitecoreService;
            }
        }
        public readonly IDictionaryPhraseRepository DictionaryPhraseRepository;
        public DictionaryPhraseRepositoryTestHarness()
        {
            _fixture = new Fixture();
            DictionaryPhraseRepository = new DictionaryPhraseRepository(SitecoreService);
        }
    }
}
