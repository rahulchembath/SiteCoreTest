using Claro.Feature.Identity.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Identity.ORM
{
    public class LogoMapping : SitecoreGlassMap<ILogo>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Logo.ID);
                config.Field(item => item.LogoImage).FieldId(Templates.Logo.Fields.LogoImage);
                config.Field(item => item.LogoUrl).FieldId(Templates.Logo.Fields.LogoUrl);


            });
        }
    }
}