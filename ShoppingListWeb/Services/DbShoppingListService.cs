using ShippingListLib;
using ShoppingListApi.Data;
using ShoppingListWeb.Models;
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

        public IList<MyItem> GetList()
        {
            return _dbContext.Items.ToList();
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
