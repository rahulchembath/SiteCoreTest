using Sitecore.Data.Items;
using System.Web;

namespace Claro.Foundation.Dictionary.Repositories
{
    public interface IDictionaryPhraseRepository
    {
        string Get(string relativePath, string defaultValue);
    }
}
