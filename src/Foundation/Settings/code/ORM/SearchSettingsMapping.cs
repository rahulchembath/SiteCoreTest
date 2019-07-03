using Claro.Foundation.Settings.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Foundation.Settings.ORM
{
    public class SearchSettingsMapping : SitecoreGlassMap<ISearchSettings>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.SearchSettings.ID);
                config.Field(item => item.SearchPageUrl).FieldId(Templates.SearchSettings.Fields.SearchPageUrl);
            });
        }
    }
}