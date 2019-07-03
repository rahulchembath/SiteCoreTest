using Claro.Foundation.ORM.Models;

namespace Claro.Foundation.Dictionary.Models
{
    public interface IDictionaryEntry: IGlassBase
    {
        string Key { get; set; }
        string Phrase { get; set; }
    }
}