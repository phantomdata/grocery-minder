using PhantomGroceries.Domain.Models;
using PhantomGroceries.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhantomGroceries.Web.Controllers
{
    [Authorize]
    public class GroceryItemsController : Controller
    {
        private readonly IGroceryItemService groceryItemService;

        public GroceryItemsController(IGroceryItemService groceryItemService)
        {
            this.groceryItemService = groceryItemService;
        }

        public ActionResult Create()
        {
            var groceryItem = new GroceryItem();
            return View(groceryItem);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var groceryItem = MapGroceryItem(collection);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var groceryItems = groceryItemService.GetAll("test");
            return View();
        }

        private GroceryItem MapGroceryItem(FormCollection collection)
        {
            var groceryItem = new GroceryItem() {
                Name = collection["Name"]
            };

            return groceryItem;
        }
    }
}