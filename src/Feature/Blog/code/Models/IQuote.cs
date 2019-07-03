using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Claro.Feature.Blog.Models
{
    public interface IQuote:IGlassBase
    {
        string Summary { get; set; }

        [SitecoreField(FieldName = Templates.Quote.Fields.AuthorFieldName, Setting = SitecoreFieldSettings.InferType)]
        IAuthor Author { get; set; }
    }
}
