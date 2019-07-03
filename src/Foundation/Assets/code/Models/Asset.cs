namespace Claro.Foundation.Assets.Models
{
    public class Asset
    {
        public Asset(string content,string itemName)
        {
            this.Content = content;
            this.ItemName = itemName;
        }
        public string Content { get;}
        public string ItemName { get; }
    }
}