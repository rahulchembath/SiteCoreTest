using System.Collections.Generic;

namespace Claro.Foundation.Indexing.Models
{
    internal class SearchResults : ISearchResults
    {
        public IEnumerable<ISearchResult> Results { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}