using Claro.Foundation.ORM.Models;

namespace Claro.Foundation.Control.Models
{
    public interface IOptionItem: IGlassBase
    {
        string ItemName { get; set; }
        int DisplayOrder { get; set; }
    }
}
