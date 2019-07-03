using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using System.Linq;
using System.Text;

namespace Claro.Foundation.Indexing.Infrastructure.Fields
{
    public class BlogCategoriesTextComputedField : IComputedIndexField
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
                StringBuilder categoryText = new StringBuilder();

                string categories = item.InnerData.Fields[Constants.Blog.Fields.BlogCategoryField];
                if (!string.IsNullOrEmpty(categories))
                {
                    categories.Split('|').ToList().ForEach(cate =>
                    {
                        var category = item.Database.GetItem(new ID(cate));
                        if (category != null)
                        {
                            string categoryName = category[Constants.Category.Fields.CategoryName];
                            if (!string.IsNullOrEmpty(categoryName))
                            {
                                categoryText.Append(categoryName.Trim().ToLower());
                            }

                        }
                    });
                    return categoryText.Length > 0 ? categoryText.ToString() : null;
                }
            }
            return null;
        }
    }
}