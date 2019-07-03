using Claro.Feature.Navigation.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Navigation.ORM
{
    public class NavigableMapping : SitecoreGlassMap<INavigable>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Navigable.ID);
                config.Field(item => item.NavigationTitle).FieldId(Templates.Navigable.Fields.NavigationTitle);
                config.Field(item => item.NavigationUrl).FieldId(Templates.Navigable.Fields.NavigationUrl);
                config.Field(item => item.DisplayOrder).FieldId(Templates.Navigable.Fields.DisplayOrder);
                config.Field(item => item.IncludeInNavigation).FieldId(Templates.Navigable.Fields.IncludeInNavigation);
                config.Children(item => item.Childrens);


            });
        }
    }
}