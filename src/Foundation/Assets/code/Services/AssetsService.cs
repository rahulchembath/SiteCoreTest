using Claro.Foundation.Assets.Repositories;
using System;
using System.Text;
using System.Web;

namespace Claro.Foundation.Assets.Services
{
    public class AssetsService
    {
        private static AssetsService _current;
        public static AssetsService Current => _current ?? (_current = new AssetsService());
        public void Resource(string file, string itemName)
        {
            AssetRepository.Current.AddResource(file, itemName);
        }
        public HtmlString RenderResource()
        {
            var sb = new StringBuilder();
            try
            {
                foreach (var item in AssetRepository.Current.Items)
                {
                    sb.Append(item?.Content).AppendLine();
                }
                return new HtmlString(sb.ToString());
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return null;
        }
    }
}