using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace Claro.Foundation.Indexing.Models
{
    public class IndexedItem : SearchResultItem
    {
        [IndexField(Constants.IndexFields.BlogCategories)]
        public List<string> Blog_Categories { get; set; }

        [IndexField(Constants.IndexFields.BlogCreatedDate)]
        public DateTime Blog_CreatedDate { get; set; }

        [IndexField(Constants.IndexFields.BlogCategories_Text)]
        public string BlogCategoryText { get; set; }
        [IndexField(Constants.IndexFields.BlogAuthor)]
        public string Blog_Author { get; set; }
        [IndexField(Constants.IndexFields.BlogTitle)]
        public string Blog_Title { get; set; }
        [IndexField(Constants.IndexFields.BlogIntro)]
        public string Blog_Intro { get; set; }
        [IndexField(Constants.IndexFields.BlogDescription)]
        public string Blog_Description { get; set; }
    }
}