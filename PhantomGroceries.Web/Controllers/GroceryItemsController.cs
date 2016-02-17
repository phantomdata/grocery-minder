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
            var vm = new Models.GroceryItems.CreateViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.GroceryItems.CreateViewModel vm)
        {
            if (ModelState.IsValid == false) return View(vm);

            var item = vm.ToGroceryItem();
            item.ApplicationUserId = User.Identity.GetUserId();

            groceryItemService.Create(item);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var groceryItems = groceryItemService.GetAll(User.Identity.GetUserId());
            return View(groceryItems.ToList());
        }

        public ActionResult Update(int id)
        {
            var item = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (item == null) return HttpNotFound();

            var vm = new Models.GroceryItems.UpdateViewModel(item);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Models.GroceryItems.UpdateViewModel vm)
        {
            if (ModelState.IsValid == false)
            {
                return View(vm);
            }

            var id = Convert.ToInt32(vm.GroceryItemId);
            var toUpdate = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (toUpdate == null) return HttpNotFound();

            var updated = vm.UpdatedGroceryItem(toUpdate);

            groceryItemService.Update(updated);

            return RedirectToAction("Index");
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