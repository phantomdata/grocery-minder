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
    public class GroceryController : BaseController
    {
        private readonly IGroceryCategoryService groceryCategoryService;
        private readonly IGroceryService groceryItemService;

        public GroceryController(IGroceryCategoryService groceryCategoryService, IGroceryService groceryItemService)
        {
            this.groceryCategoryService = groceryCategoryService;
            this.groceryItemService = groceryItemService;
        }

        public ActionResult Create()
        {
            var vm = new Models.Grocery.CreateViewModel();
            vm.AvailableGroceryCategories = getAvailableCategories();
            vm.LastPurchasedAt = DateTime.Now;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.Grocery.CreateViewModel vm)
        {
            if (ModelState.IsValid == false)
            {
                vm.AvailableGroceryCategories = getAvailableCategories();
                return View(vm);
            }

            var item = vm.ToGroceryItem();
            item.ApplicationUserId = UserId;

            if (groceryCategoryService.GetAll(UserId).Any(c => c.Id == item.GroceryCategoryId) == false)
            {
                return HttpNotFound(); // Ugh, there's no helper for 401 or 403
            }

            groceryItemService.Create(item);

            TempData["SuccessMessage"] = "Successfully created the item.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = groceryItemService.Get(UserId, id);
            if (item == null) return HttpNotFound();

            groceryItemService.Delete(item);

            TempData["SuccessMessage"] = "Successfully deleted the item.";

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var items = groceryItemService.GetAll(UserId)
                .OrderBy(i => i.GroceryCategory.Name)
                .ThenBy(i => i.Name);
            return View(items.ToList());
        }

        public ActionResult Update(int id)
        {
            var item = groceryItemService.Get(UserId, id);
            if (item == null) return HttpNotFound();

            var vm = new Models.Grocery.UpdateViewModel(item);
            vm.AvailableGroceryCategories = getAvailableCategories();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Models.Grocery.UpdateViewModel vm)
        {
            if (ModelState.IsValid == false)
            {
                vm.AvailableGroceryCategories = getAvailableCategories();
                return View(vm);
            }

            var id = Convert.ToInt32(vm.Id);
            var toUpdate = groceryItemService.Get(UserId, id);
            if (toUpdate == null) return HttpNotFound();

            var updated = vm.UpdatedGroceryItem(toUpdate);

            if (groceryCategoryService.GetAll(UserId).Any(c => c.Id == updated.GroceryCategoryId) == false)
            {
                return HttpNotFound(); // Ugh, there's no helper for 401 or 403
            }

            groceryItemService.Update(updated);

            TempData["SuccessMessage"] = "Successfully updated item.";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets the listing of available categories for the user.  Intended
        /// to be used for dropdown population.
        /// </summary>
        private IList<SelectListItem> getAvailableCategories()
        {
            var ret = groceryCategoryService
                .GetAll(UserId)
                .OrderBy(c => c.Priority)
                .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
                .ToList();

            return ret;
        }
    }
}