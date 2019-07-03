using Claro.Feature.Social.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Social.ORM
{
    public class SocialFollowFolderMapping : SitecoreGlassMap<ISocialFollowFolder>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Children(item => item.SocialFollow);
            });
        }
    }
}