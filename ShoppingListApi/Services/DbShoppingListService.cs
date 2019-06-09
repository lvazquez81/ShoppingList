using ShippingListLib;
using ShoppingListApi.Data;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListApi.Services
{
    public class DbShoppingListService : IShoppingListService
    {
        private readonly ShoppingListDbContext _dbContext;

        public DbShoppingListService(ShoppingListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddItem(string itemName)
        {
            var myItem = new MyItem()
            {
                Item = itemName
            };

            _dbContext.Items.Add(myItem);
            _dbContext.SaveChanges();

            return myItem.Id;
        }

        public IDictionary<int, string> GetList()
        {
            var lookupQuery = from x in _dbContext.Items
                              select new MyItem()
                              {
                                  Id = x.Id,
                                  Item = x.Item
                              };

            return lookupQuery.ToDictionary(x => x.Id, x => x.Item);
        }

        public bool RemoveItem(int itemId)
        {
            var myItem = _dbContext.Items.Where(x => x.Id == itemId);
            if (myItem.Any())
            {
                _dbContext.Items.Remove(myItem.First());
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
