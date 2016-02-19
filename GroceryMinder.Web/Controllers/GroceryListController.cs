using GroceryMinder.Service.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class GroceryListController : Controller
    {
        private string _userId { get; set; } // Not meant to be used beyond following scope
        private string UserId
        {
            get
            {
                if (_userId == null)
                {
                    _userId = User.Identity.GetUserId();
                }
                return _userId;
            }
        }

        private readonly IGroceryService groceryService;

        public GroceryListController(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }

        public ActionResult Index()
        {
            // Give some fudge in case they decide to go shopping early
            var cutoffDate = DateTime.Today.AddDays(-3);

            var vm = new Models.GroceryList.Index();

            vm.GroceryList = groceryService.GetAll(UserId)
                .Where(g => g.NextPurchaseAt <= cutoffDate)
                .OrderBy(g => g.GroceryCategory.Name)
                .ThenBy(g => g.Name)
                .ToList();

            return View(vm);
        }
    }
}