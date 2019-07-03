using System.Collections.Generic;

namespace Claro.Foundation.Indexing.Models
{
    public class SearchQuery : IQuery
    {
        public int NoOfResults { get; set; }
        public int Page { get; set; }
        public string Category { get; set; }
        public List<string> ExcludeArticles { get; set; }
        public string SearchText { get; set; }
    }
}