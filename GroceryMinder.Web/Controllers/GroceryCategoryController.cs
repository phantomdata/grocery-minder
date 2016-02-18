using GroceryMinder.Service.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    [Authorize]
    public class GroceryCategoryController : Controller
    {
        private readonly IGroceryCategoryService groceryCategoryService;

        public GroceryCategoryController(IGroceryCategoryService groceryCategoryService)
        {
            this.groceryCategoryService = groceryCategoryService;
        }

        public ActionResult Create()
        {
            var vm = new Models.GroceryCategory.CreateViewModel();

            var lastGroceryCategory = groceryCategoryService.GetAll(User.Identity.GetUserId()).OrderByDescending(c => c.Priority).FirstOrDefault();
            if (lastGroceryCategory != null)
            {
                vm.Priority = lastGroceryCategory.Priority + 1;
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.GroceryCategory.CreateViewModel vm)
        {
            if (ModelState.IsValid == false) return View(vm);

            var item = vm.ToGroceryCategory();
            item.ApplicationUserId = User.Identity.GetUserId();

            groceryCategoryService.Create(item);

            TempData["SuccessMessage"] = "Successfully created the item.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = groceryCategoryService.Get(User.Identity.GetUserId(), id);
            if (item == null) return HttpNotFound();

            groceryCategoryService.Delete(item);

            TempData["SuccessMessage"] = "Successfully deleted the item.";

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var items = groceryCategoryService.GetAll(User.Identity.GetUserId()).OrderBy(c => c.Priority);
            return View(items.ToList());
        }

        public ActionResult Update(int id)
        {
            var item = groceryCategoryService.Get(User.Identity.GetUserId(), id);
            if (item == null) return HttpNotFound();

            var vm = new Models.GroceryCategory.UpdateViewModel(item);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(Models.GroceryCategory.UpdateViewModel vm)
        {
            if (ModelState.IsValid == false)
            {
                return View(vm);
            }

            var id = Convert.ToInt32(vm.GroceryCategoryId);
            var toUpdate = groceryCategoryService.Get(User.Identity.GetUserId(), id);
            if (toUpdate == null) return HttpNotFound();

            var updated = vm.UpdatedGroceryCategory(toUpdate);

            groceryCategoryService.Update(updated);

            TempData["SuccessMessage"] = "Successfully updated item.";

            return RedirectToAction("Index");
        }
    }
}