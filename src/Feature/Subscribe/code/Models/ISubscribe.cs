using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;

namespace Claro.Feature.Subscribe.Models
{
    public interface ISubscribe:IGlassBase
    {
        Link SalesforceLink { get; set; }
        string Benefit { get; set; }
    }
}
