using Microsoft.AspNet.Identity;
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
            groceryItem.ApplicationUserId = User.Identity.GetUserId();

            groceryItemService.Create(groceryItem);
            // TODO: Add validation.  Ops.
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var groceryItems = groceryItemService.GetAll(User.Identity.GetUserId());
            return View(groceryItems.ToList());
        }

        [HttpPost]
        public ActionResult Update(FormCollection collection)
        {
            var id = Convert.ToInt32(collection["GroceryItemId"]);
            var toUpdate = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (toUpdate == null) return HttpNotFound();

            var mapped = MapGroceryItem(collection, toUpdate);

            groceryItemService.Update(mapped);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var groceryItem = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (groceryItem == null) return HttpNotFound();

            return View(groceryItem);
        }

        private GroceryItem MapGroceryItem(FormCollection collection)
        {
            var item = new GroceryItem() {
                Name = collection["Name"]
            };

            return item;
        }
        private GroceryItem MapGroceryItem(FormCollection collection, GroceryItem item)
        {
            item.Name = collection["Name"];

            return item;
        }
    }
}