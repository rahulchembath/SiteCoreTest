using Claro.Foundation.Dictionary.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Foundation.Dictionary.ORM
{
    public class DictionaryEntryMapping:SitecoreGlassMap<IDictionaryEntry>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Dictionary.ID);
                config.Field(item => item.Key).FieldId(Templates.Dictionary.Fields.key);
                config.Field(item => item.Phrase).FieldId(Templates.Dictionary.Fields.Phrase);


            });
        }
    }
}