using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class QuoteMapping : SitecoreGlassMap<IQuote>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Quote.ID);
                config.Field(item => item.Summary).FieldId(Templates.Quote.Fields.Summary);
            });
        }
    }
}