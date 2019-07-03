using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;

namespace Claro.Foundation.Indexing.Infrastructure.Fields
{
    public class BlogAuthorComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var indexItem = indexable as SitecoreIndexableItem;
            if (indexItem == null)
            {
                return null;
            }
            var item = indexItem.Item;
            if (item.TemplateID == Constants.ArticlePage)
            {
                string authorItem = item.InnerData.Fields[Constants.Blog.Fields.BlogAuthorField];
                if (!string.IsNullOrEmpty(authorItem))
                {
                    var author = item.Database.GetItem(new ID(authorItem));
                    if (author != null)
                    {
                        string firtName = author[Constants.Author.Fields.FirstName];
                        string lastName = author[Constants.Author.Fields.LastName];
                        if (!string.IsNullOrEmpty(firtName) || !string.IsNullOrEmpty(lastName))
                        {
                            return firtName + " " + lastName;
                        }

                    }
                }
            }
            return null;
        }
    }
}