using Sitecore;
using Sitecore.Buckets.Managers;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Linq;

namespace Claro.Feature.Blog.Pipelines.Resolver
{
    public class BucketItemResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            try
            {
                if (Context.Item == null)
                {
                    var requestUrl = args.Url.ItemPath;

                    // remove last element from path and see if resulting pathis a bucket
                    var index = requestUrl.LastIndexOf('/');
                    if (index > 0)
                    {
                        var bucketPath = requestUrl.Substring(0, index);
                        var bucketItem = args.GetItem(bucketPath);

                        if (bucketItem != null && BucketManager.IsBucket(bucketItem))
                        {
                            string itemName = requestUrl.Substring(index + 1);
                            if (!string.IsNullOrEmpty(itemName))
                            {
                                itemName = MainUtil.DecodeName(itemName);
                            }
                            // locate item in bucket by name
                            using (var context = ContentSearchManager.GetIndex(Constants.CustomIndex).CreateSearchContext())
                            {
                                var result = context.GetQueryable<SearchResultItem>().Where(x => x.Name == itemName).FirstOrDefault();
                                if (result != null)
                                {
                                    Context.Item = args.GetItem(result.ItemId);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
        }
    }
}