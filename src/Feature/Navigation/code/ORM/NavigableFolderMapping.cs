using Claro.Feature.Navigation.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Navigation.ORM
{
    public class NavigableFolderMapping : SitecoreGlassMap<INavigableFolder>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.NavigableFolder.ID);
                config.Children(item => item.NavigableItem);
            });
        }
    }
}