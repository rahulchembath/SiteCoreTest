using System.Collections.Generic;

namespace Claro.Feature.Blog.Models
{
    public class BlogListViewModel
    {
        public List<BlogViewModel> Blogs { get; set; }
        public string Quote { get; set; }
        public string QuotesAuthor { get; set; }
        public string FeatureArticleId { get; set; }
        public int QuotePosition { get; set; }
        public bool IsQuoteLocationRight { get; set; }
        public bool IsQuotesRequired { get; set; }
        public string Category { get; set; }
    }
}