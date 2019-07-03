using System.Collections.Generic;

namespace Claro.Foundation.Indexing.Models
{
    public interface ISearchResults
    {
        IEnumerable<ISearchResult> Results { get; }
        int PageSize { get; }
        int PageNo { get; }
    }
}
