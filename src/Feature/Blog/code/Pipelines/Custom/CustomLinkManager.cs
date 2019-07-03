using Sitecore;
using Sitecore.Buckets.Extensions;
using Sitecore.Buckets.Managers;
using Sitecore.IO;
using Sitecore.Links;
using System;

namespace Claro.Feature.Blog.Pipelines.Custom
{
    public class CustomLinkManager : LinkProvider
    {
        public override string GetItemUrl(Sitecore.Data.Items.Item item, UrlOptions options)
        {
            try
            {
                if (BucketManager.IsItemContainedWithinBucket(item))
                {
                    var bucketItem = item.GetParentBucketItemOrParent();
                    if (bucketItem != null && bucketItem.IsABucket())
                    {
                        var bucketUrl = base.GetItemUrl(bucketItem, options);
                        string itemName = MainUtil.EncodeName(item.Name);
                        return FileUtil.MakePath(bucketUrl, itemName);
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return base.GetItemUrl(item, options);
        }
    }
}