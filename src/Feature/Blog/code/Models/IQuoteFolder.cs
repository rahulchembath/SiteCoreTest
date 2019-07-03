using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System.Collections.Generic;

namespace Claro.Feature.Blog.Models
{
    public interface IQuoteFolder:IGlassBase
    {
        [SitecoreChildren(InferType = true)]
        IEnumerable<IQuote> Quotes { get; set; }
    }
}
