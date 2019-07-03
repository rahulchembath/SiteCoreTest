using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Feature.Blog.Models
{
    public interface ICategoryFolder : IGlassBase
    {
        [SitecoreChildren(InferType = true)]
        IEnumerable<ICategory> Categories { get; set; }
    }
}
