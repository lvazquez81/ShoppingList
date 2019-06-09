using System.Collections.Generic;

namespace ShippingListLib
{
    /// <summary>
    /// Basic shopping list implementation with internal collection
    /// </summary>
    public class DumbShoppingListService : IShoppingListService
    {
        private readonly IDictionary<int, string> _data;

        public DumbShoppingListService()
        {
            _data = new Dictionary<int, string>();
        }

        public int AddItem(string itemName)
        {
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                int id = _data.Count + 1;

                _data.Add(id, itemName);

                return id;
            }
            else
            {
                return -1;
            }

        }

        public IDictionary<int, string> GetList()
        {
            return _data;
        }

        public bool RemoveItem(int itemId)
        {
            if (_data?.ContainsKey(itemId) ?? false)
            {
                _data.Remove(itemId);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
