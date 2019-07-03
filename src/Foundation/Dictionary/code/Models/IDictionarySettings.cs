using Claro.Foundation.ORM.Models;

namespace Claro.Foundation.Dictionary.Models
{
    public interface IDictionarySettings:IGlassBase
    {
        string DictionaryPath { get; set; }
    }
}
