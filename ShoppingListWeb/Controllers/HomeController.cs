using Microsoft.AspNetCore.Mvc;
using ShippingListLib;
using ShoppingListWeb.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShoppingListWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShoppingListService _data;

        public HomeController(IShoppingListService dataSource)
        {
            _data = dataSource;
        }

        public IActionResult Index()
        {
            IList<MyItem> items = _data.GetList();

            return View(items);
        }

        public IActionResult Add(string txtItem)
        {
            if (!string.IsNullOrWhiteSpace(txtItem))
            {
                _data.AddItem(txtItem);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _data.RemoveItem(id);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
