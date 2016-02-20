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
    public class GroceryListController : BaseController
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IGroceryService groceryService;

        public GroceryListController(IApplicationUserService applicationUserService, IGroceryService groceryService)
        {
            this.applicationUserService = applicationUserService;
            this.groceryService = groceryService;
        }

        public ActionResult Index()
        {
            var nextTripDate = ApplicationUser.NextShoppingTripAt;

            var cutoff = nextTripDate.AddDays(2); // Give some fudge
            var items = groceryService.GetAll(UserId)
                .Where(g => g.NextPurchaseAt <= cutoff)
                .OrderBy(g => g.GroceryCategory.Priority)
                .ThenBy(g => g.Name);

            var totalCost = items.Count() > 0 ? items.Sum(g => g.AverageCost) : 0;

            var vm = new Models.GroceryList.Index()
            {
                GroceryList = items.ToList(),
                LastWentShoppingAt = ApplicationUser.LastWentShoppingAt,
                NextTripDate = nextTripDate,
                TotalCost = totalCost
            };

            return View(vm);
        }
    }
}