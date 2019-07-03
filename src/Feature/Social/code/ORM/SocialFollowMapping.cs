using Claro.Feature.Social.Models;
using Glass.Mapper.Sc.Maps;


namespace Claro.Feature.Social.ORM
{
    public class SocialFollowMapping : SitecoreGlassMap<ISocialFollow>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.SocialFollow.ID);
                config.Field(item => item.SocialMediaName).FieldId(Templates.SocialFollow.Fields.SocialMediaName);
                config.Field(item => item.SocialMediaUrl).FieldId(Templates.SocialFollow.Fields.SocialMediaUrl);
                config.Field(item => item.DisplayOrder).FieldId(Templates.SocialFollow.Fields.DisplayOrder);
            });
        }
    }
}