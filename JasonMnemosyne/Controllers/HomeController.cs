using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JasonMnemosyne.Models;
using JasonMnemosyne.JsonDataLayer;

namespace JasonMnemosyne.Controllers
{
    public class HomeController : Controller
    {
        private IService _jsonDataService;

        public HomeController(IService service)
        {
            _jsonDataService = service;
        }

        private static List<ShoppingItem> SeedShoppingList()
        {
            List<ShoppingItem> shoppingList = new List<ShoppingItem>
            {
                new ShoppingItem(1, "Milk"),
                new ShoppingItem(2, "Potatoes"),
                new ShoppingItem(3, "Bread"),
                new ShoppingItem(4, "Butter")
            };
            return shoppingList;
        }

        public IActionResult JsonIndex()
        {
            List<ShoppingItem> shopList1 = SeedShoppingList();
            _jsonDataService.AddDataList<ShoppingItem>(shopList1);

            List<ShoppingItem> shopList2 = _jsonDataService.GetDataList<ShoppingItem>();


            return View(shopList2);
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
