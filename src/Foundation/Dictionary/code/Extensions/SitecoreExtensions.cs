using Claro.Foundation.Dictionary.Repositories;
using Sitecore.Mvc.Helpers;

namespace Claro.Foundation.Dictionary.Extensions
{
    public static class SitecoreExtensions
    {
        public static string Dictionary(this SitecoreHelper helper, string relativePath, string defaultValue = "")
        {
            return DictionaryPhraseRepository.Current.Get(relativePath, defaultValue);
        }
    }
}