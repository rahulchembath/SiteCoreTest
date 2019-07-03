using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;
namespace Claro.Feature.Social.Models
{
    public interface ISocialFollow:IGlassBase
    {
        string SocialMediaName { get; set; }
        Link SocialMediaUrl { get; set; }
        int DisplayOrder { get; set; }
    }
}
