using Claro.Foundation.Dictionary.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Foundation.Dictionary.ORM
{
    public class DictionarySettingsMapping:SitecoreGlassMap<IDictionarySettings>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.DictionarySetting.ID);
                config.Field(item => item.DictionaryPath).FieldId(Templates.DictionarySetting.Fields.DictionaryPath);
            });
        }
    }
}