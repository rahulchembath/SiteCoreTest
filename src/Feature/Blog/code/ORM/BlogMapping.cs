using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class BlogMapping : SitecoreGlassMap<IBlog>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Blog.ID);
                config.Field(item => item.Title).FieldId(Templates.Blog.Fields.Title);
                config.Field(item => item.Intro).FieldId(Templates.Blog.Fields.Intro);
                config.Field(item => item.Description).FieldId(Templates.Blog.Fields.Description);
                config.Field(item => item.LandingBoxImage).FieldId(Templates.Blog.Fields.LandingBoxImage);
                config.Field(item => item.HeroImage).FieldId(Templates.Blog.Fields.HeroImage);
                config.Field(item => item.FeatureImage).FieldId(Templates.Blog.Fields.FeatureImage);
                config.Field(item => item.BlogCreated).FieldId(Templates.Blog.Fields.BlogCreated);
            });
        }
    }
    public class BlogBaseMapping : SitecoreGlassMap<IBlog>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
            });
        }
    }
}