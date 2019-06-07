using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingListLib;
using ShoppingListApi.Data;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingListApi.Controllers
{
    [Route("api/shopping")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingListService _data;

        public ShoppingController(IShoppingListService dataSource)
        {
            _data = dataSource;
        }

        [HttpGet]
        [ActionName("Index")]
        [Produces("application/json")]
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<string>> AddItem([FromBody]AddItem item)
        {
            int id = _data.AddItem(item.Item);

            if (id > 0)
            {
                return Ok(GetShoppingItems());
            }
            else
            {
                return BadRequest($"Unable to add item: {item.Item}");
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
