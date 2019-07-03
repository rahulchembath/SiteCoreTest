using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;

namespace Claro.Feature.Teaser.Models
{
    public interface ISlogan:IGlassBase
    {
        Image SloganImage { get; set; }
    }
}
