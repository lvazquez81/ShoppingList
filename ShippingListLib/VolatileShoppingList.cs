using System.Collections.Generic;

namespace ShippingListLib
{
    /// <summary>
    /// Basic shopping list implementation with internal collection
    /// </summary>
    public class VolatileShoppingList : IShoppingList
    {
        private readonly IList<string> _list;

        public VolatileShoppingList()
        {
            _list = new List<string>();
        }

        public int AddItem(string itemName)
        {
            _list.Add(itemName);
            return _list.Count;
        }

        public IList<string> GetList()
        {
            return _list;
        }

        public bool RemoveItem(int itemId)
        {
            if (itemId > 0 && itemId <= _list.Count)
            {
                _list.RemoveAt(itemId - 1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
