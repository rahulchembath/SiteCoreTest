using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;

namespace Claro.Feature.Navigation.Models
{
    public interface INavigable:IGlassBase
    {
        string NavigationTitle { get; set; }
        Link NavigationUrl { get; set; }
        bool IncludeInNavigation { get; set; }
        int DisplayOrder { get; set; }
        [SitecoreChildren(InferType = true)]
        IEnumerable<INavigable> Childrens { get; set; }
    }
}
