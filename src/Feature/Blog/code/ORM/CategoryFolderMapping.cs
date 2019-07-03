using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class CategoryFolderMapping : SitecoreGlassMap<ICategoryFolder>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.CategoryFolder.ID);
                config.Children(item => item.Categories);
            });
        }
    }
}