using GroceryMinder.Domain.Models;
using GroceryMinder.Service.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class ShoppingTokenController : BaseController
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly IGroceryService groceryService;
        private readonly IGroceryListService groceryListService;
        private readonly IShoppingTokenService shoppingTokenService;

        public ShoppingTokenController(
            IApplicationUserService applicationUserService,
            IGroceryService groceryService,
            IGroceryListService groceryListService,
            IShoppingTokenService shoppingTokenService)
        {
            this.applicationUserService = applicationUserService;
            this.groceryService = groceryService;
            this.groceryListService = groceryListService;
            this.shoppingTokenService = shoppingTokenService;
        }

        public ActionResult Consume(Guid id)
        {
            var shoppingToken = shoppingTokenService.Get(id);
            if (shoppingToken == null) return View(); // We really don't care

            var user = shoppingToken.ApplicationUser;
            user.LastWentShoppingAt = DateTime.Now;
            user.NextShoppingTripAt = applicationUserService.GetNextTripDate(user);

            var groceries = groceryListService.Get(ApplicationUser, UserId).Groceries;
            foreach(var grocery in groceries)
            {
                grocery.LastPurchasedAt = DateTime.Now;
                groceryService.Update(grocery, false);
            }

            // Since OWIN is so fucked up, we're relying on the commit from delete
            // to affect the user change.

            shoppingTokenService.Delete(id);

            return View();
        }
    }
}