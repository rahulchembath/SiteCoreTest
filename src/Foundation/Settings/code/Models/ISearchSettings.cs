using Claro.Foundation.ORM.Models;

namespace Claro.Foundation.Settings.Models
{
    public interface ISearchSettings : IGlassBase
    {
        string SearchPageUrl { get; set; }
    }
}
