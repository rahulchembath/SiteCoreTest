using Claro.Foundation.Dictionary.Models;
using Glass.Mapper.Sc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore;
using Sitecore.DependencyInjection;
using System;
using System.Web;

namespace Claro.Foundation.Dictionary.Repositories
{
    public class DictionaryPhraseRepository : IDictionaryPhraseRepository
    {
        private readonly ISitecoreService _sitecoreService;
        public DictionaryPhraseRepository(ISitecoreService sitecoreService)
        {
            _sitecoreService = sitecoreService;
        }

        public static IDictionaryPhraseRepository Current => GetCurrentFromCacheOrCreate();
        public static IDictionaryPhraseRepository GetCurrentFromCacheOrCreate()
        {
            if (HttpContext.Current != null)
            {
                var repository = HttpContext.Current.Items["DictionaryPhraseRepository.Current"] as IDictionaryPhraseRepository;
                if (repository != null)
                {
                    return repository;
                }
            }
            IDictionaryPhraseRepository dictionaryPhraseRepository = ServiceLocator.ServiceProvider.GetService<IDictionaryPhraseRepository>();
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items.Add("DictionaryPhraseRepository.Current", dictionaryPhraseRepository);
            }
            return dictionaryPhraseRepository;
        }
        public string Get([NotNull] string relativePath, string defaultValue)
        {
            if (relativePath == null)
            {
                throw new ArgumentNullException(nameof(relativePath));
            }
            if (Context.Database == null)
            {
                return defaultValue;
            }
            var dictionaryItem = GetDictionaryFieldValue(relativePath, defaultValue);
            if (string.IsNullOrEmpty(dictionaryItem))
            {
                return defaultValue;
            }
            return dictionaryItem;

        }

        private string GetDictionaryFieldValue(string relativePath, string defaultValue)
        {
            //Get Dicitionary Path from Site Root path
            IDictionarySettings dictionarySettings = _sitecoreService.GetItem<IDictionarySettings>(Context.Site?.RootPath);
            var fullPath = dictionarySettings?.DictionaryPath + relativePath;
            var dictionaryItem = _sitecoreService.GetItem<IDictionaryEntry>(fullPath);
            if (dictionaryItem != null)
            {
                return dictionaryItem.Phrase ?? defaultValue;
            }
            return defaultValue;

        }
    }
}