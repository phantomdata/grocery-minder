using Microsoft.AspNet.Identity;
using GroceryMinder.Domain.Models;
using GroceryMinder.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    [Authorize]
    public class GroceryController : Controller
    {
        private readonly IGroceryService groceryItemService;

        public GroceryController(IGroceryService groceryItemService)
        {
            this.groceryItemService = groceryItemService;
        }

        public ActionResult Create()
        {
            var vm = new Models.Grocery.CreateViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.Grocery.CreateViewModel vm)
        {
            if (ModelState.IsValid == false) return View(vm);

            var item = vm.ToGroceryItem();
            item.ApplicationUserId = User.Identity.GetUserId();

            groceryItemService.Create(item);

            TempData["SuccessMessage"] = "Successfully created the item.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (item == null) return HttpNotFound();

            groceryItemService.Delete(item);

            TempData["SuccessMessage"] = "Successfully deleted the item.";

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var items = groceryItemService.GetAll(User.Identity.GetUserId());
            return View(items.ToList());
        }

        public ActionResult Update(int id)
        {
            var item = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (item == null) return HttpNotFound();

            var vm = new Models.Grocery.UpdateViewModel(item);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Models.Grocery.UpdateViewModel vm)
        {
            if (ModelState.IsValid == false)
            {
                return View(vm);
            }

            var id = Convert.ToInt32(vm.Id);
            var toUpdate = groceryItemService.Get(User.Identity.GetUserId(), id);
            if (toUpdate == null) return HttpNotFound();

            var updated = vm.UpdatedGroceryItem(toUpdate);

            groceryItemService.Update(updated);

            TempData["SuccessMessage"] = "Successfully updated item.";

            return RedirectToAction("Index");
        }
    }
}