using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class QuoteFolderMapping : SitecoreGlassMap<IQuoteFolder>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.QuoteFolder.ID);
                config.Children(item => item.Quotes);
            });
        }
    }
}