using Claro.Foundation.Assets.Models;
using System.Collections.Generic;
using System.Linq;

namespace Claro.Foundation.Assets.Repositories
{
    public class AssetRepository
    {
        private static AssetRepository _current;

        private readonly List<Asset> _items = new List<Asset>();
        internal IEnumerable<Asset> Items => this._items;
        public static AssetRepository Current => _current ?? (_current = new AssetRepository());
        internal void Clear()
        {
            lock (_items)
            {
                this._items.Clear();
            }
        }
        public void AddResource(string file, string itemName)
        {
            Asset asset = new Asset(file, itemName);
            lock (_items)
            {
                if (!this._items.Any(x => x.ItemName == asset.ItemName))
                {
                    this._items.Add(asset);
                }
            }
        }
    }
}