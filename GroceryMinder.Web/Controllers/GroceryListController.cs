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

        private readonly IGroceryService groceryService;

        public GroceryListController(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }

        public ActionResult Index()
        {
            // TODO: Factor this out
            DateTime nextTripDate;
            if (ApplicationUser.LastWentShoppingAt < DateTime.Now.AddDays(-7) || ApplicationUser.LastWentShoppingAt > DateTime.Now)
            {
                nextTripDate = DateTime.Now;
            }
            else {
                nextTripDate = ApplicationUser.LastWentShoppingAt.AddDays(7); // Assume a weekly trip for now
            }

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