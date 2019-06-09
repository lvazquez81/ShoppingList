using Microsoft.AspNetCore.Mvc;
using ShoppingListWeb.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShoppingListWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IList<MyItem> items = new List<MyItem>()
            {
                new MyItem(1, "Eggs"),
                new MyItem(2, "Bacon")
            };

            return View(items);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete()
        {
            IList<MyItem> items = new List<MyItem>()
            {
                new MyItem(1, "Eggs"),
                new MyItem(2, "Bacon")
            };

            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
