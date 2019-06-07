using Microsoft.AspNetCore.Mvc;
using ShippingListLib;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApi.Controllers
{
    [Route("api/shopping")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private IShoppingListService _data;

        public ShoppingController()
        {
            _data = new DumbShoppingListService();

            // sample values
            _data.AddItem("Milk");
            _data.AddItem("Eggs");
        }

        [HttpGet]
        public ActionResult<IList<string>> GetShoppingList()
        {
            return Ok(GetShoppingItems());
        }

        private IEnumerable<string> GetShoppingItems()
        {
            var itemQuery = from x in _data.GetList()
                            select x.Value;

            return itemQuery.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> AddItem()
        {
            string itemName = await Request.GetRawBodyStringAsync();
            int id = _data.AddItem(itemName);

            if(id > 0)
            {
                return Ok(GetShoppingItems());
            }
            else
            {
                return BadRequest($"Unable to add item: {itemName}");
            }

            
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> RemoveItem([FromBody] int id)
        {
            bool result = _data.RemoveItem(id);

            if (result)
            {
                return Ok(GetShoppingItems());
            }
            else
            {
                return BadRequest($"Unable to remove item with id: {id}");
            }
        }
    }
}
