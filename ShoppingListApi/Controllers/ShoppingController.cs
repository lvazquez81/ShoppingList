using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingListLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApi.Controllers
{
    [Route("api/shopping")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private IShoppingList _list;

        public ShoppingController()
        {
            _list = new VolatileShoppingList();

            // sample values
            _list.AddItem("Milk");
            _list.AddItem("Eggs");
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetShoppingList()
        {
            return _list.GetList().ToList();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> AddItem()
        {
            string itemName = await Request.GetRawBodyStringAsync();
            _list.AddItem(itemName);

            return _list.GetList().ToList();
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> RemoveItem([FromBody] int id)
        {
            bool result = _list.RemoveItem(id);

            return _list.GetList().ToList();
        }
    }
}
