using System.Collections.Generic;

namespace Claro.Foundation.Indexing.Models
{
    public interface IQuery
    {
        int NoOfResults { get; set; }
        int Page { get; set; }
        string Category { get; set; }
       List<string> ExcludeArticles { get; set; }
        string SearchText { get; set; }
    }
}
