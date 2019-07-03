using Claro.Foundation.Control.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Foundation.Control.ORM
{
    public class OptionItemMapping : SitecoreGlassMap<IOptionItem>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.OptionItem.ID);
                config.Field(item => item.ItemName).FieldId(Templates.OptionItem.Fields.ItemName);
                config.Field(item => item.DisplayOrder).FieldId(Templates.OptionItem.Fields.DisplayOrder);
            });
        }
    }
}