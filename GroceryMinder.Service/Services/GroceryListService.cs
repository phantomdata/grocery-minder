using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IGroceryListService
    {
        GroceryList Get(ApplicationUser applicationUser, string applicationUserId);
    }

    public class GroceryListService : IGroceryListService
    {
        private IGroceryService groceryService;

        public GroceryListService(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }

        public GroceryList Get(ApplicationUser applicationUser, string applicationUserId)
        {
            var nextTripDate = applicationUser.NextShoppingTripAt;
            var delta = (nextTripDate - DateTime.Now).Days;

            var fudgeFactor = 0;
            if (delta < 3) fudgeFactor = 2;
            if (delta < 2) fudgeFactor = 3;

            var cutoff = nextTripDate.AddDays(fudgeFactor);
            var items = groceryService.GetAll(applicationUserId)
                .Where(g => g.NextPurchaseAt <= cutoff)
                .OrderBy(g => g.GroceryCategory.Priority)
                .ThenBy(g => g.Name);

            var totalCost = items.Count() > 0 ? items.Sum(g => g.AverageCost) : 0;

            return new GroceryList() { Date = applicationUser.NextShoppingTripAt, Groceries = items.ToList(), TotalCost = totalCost };
        }
    }
}
