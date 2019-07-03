using Claro.Foundation.Assets.Repositories;
using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

namespace Claro.Foundation.Assets.Pipelines.GetPageRendering
{
    public class ClearAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            AssetRepository.Current.Clear();
        }
    }
}