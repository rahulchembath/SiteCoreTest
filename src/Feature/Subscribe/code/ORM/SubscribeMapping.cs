using Claro.Feature.Subscribe.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Subscribe.ORM
{
    public class SubscribeMapping : SitecoreGlassMap<ISubscribe>
    {
        public override void Configure()
        {
            Map(Config =>
            {
                Config.AutoMap();
                Config.TemplateId(Templates.Subscribe.ID);
                Config.Field(item => item.SalesforceLink).FieldId(Templates.Subscribe.Fields.SalesforceLink);
                Config.Field(item => item.Benefit).FieldId(Templates.Subscribe.Fields.Benefit);
            });
        }
    }
}