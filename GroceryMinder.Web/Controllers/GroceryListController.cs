using GroceryMinder.Service.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class GroceryListController : BaseController
    {

        private readonly IGroceryService groceryService;

        public GroceryListController(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }

        public ActionResult Index()
        {
            // Give some fudge in case they decide to go shopping early
            var cutoffDate = DateTime.Today.AddDays(-3);
            
            var items = groceryService.GetAll(UserId)
                .Where(g => g.NextPurchaseAt <= cutoffDate)
                .OrderBy(g => g.GroceryCategory.Name)
                .ThenBy(g => g.Name);

            var totalCost = items.Sum(g => g.AverageCost);

            var vm = new Models.GroceryList.Index()
            {
                GroceryList = items.ToList(),
                TotalCost = totalCost
            };

            return View(vm);
        }
    }
}