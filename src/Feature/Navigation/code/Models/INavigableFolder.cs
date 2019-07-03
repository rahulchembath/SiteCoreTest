using Claro.Foundation.ORM.Models;
using System.Collections.Generic;

namespace Claro.Feature.Navigation.Models
{
    public interface INavigableFolder:IGlassBase
    {
        IEnumerable<INavigable> NavigableItem { get; set; }
    }
}