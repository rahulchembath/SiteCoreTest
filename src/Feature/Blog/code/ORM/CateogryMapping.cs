using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class CateogryMapping : SitecoreGlassMap<ICategory>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Category.ID);
                config.Field(item => item.CategoryTitle).FieldId(Templates.Category.Fields.Title);
                config.Field(item => item.CategoryUrl).FieldId(Templates.Category.Fields.Url);
                config.Field(item => item.DisplayOrder).FieldId(Templates.Category.Fields.DisplayOrder);
            });
        }
    }
}