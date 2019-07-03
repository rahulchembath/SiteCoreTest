using Claro.Foundation.Settings.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Foundation.Settings.ORM
{
    public class ItemPathSettingsMapping : SitecoreGlassMap<IItemPathSettings>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.ItemPathSettings.ID);
                config.Field(item => item.QuoteUrl).FieldId(Templates.ItemPathSettings.Fields.QuoteUrl);
            });
        }
    }
}