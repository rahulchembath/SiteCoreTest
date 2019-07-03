using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;

namespace Claro.Feature.Identity.Models
{
    public interface ILogo: IGlassBase
    {
        Image LogoImage { get; set; }
        Link LogoUrl { get; set; }
    }
}
