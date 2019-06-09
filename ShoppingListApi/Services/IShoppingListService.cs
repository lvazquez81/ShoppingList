using System.Collections.Generic;

namespace ShippingListLib
{
    /// <summary>
    /// Basic shopping list operations
    /// </summary>
    public interface IShoppingListService
    {
        /// <summary>
        /// Add item to our list
        /// </summary>
        int AddItem(string itemName);

        /// <summary>
        /// See what is in the list
        /// </summary>
        IDictionary<int, string> GetList();

        /// <summary>
        /// Remove any existing item
        /// </summary>
        bool RemoveItem(int itemId);
    }
}
