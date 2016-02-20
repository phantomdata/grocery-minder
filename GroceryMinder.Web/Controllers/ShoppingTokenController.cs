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
        private readonly IShoppingTokenService shoppingTokenService;

        public ShoppingTokenController(IApplicationUserService applicationUserService, IShoppingTokenService shoppingTokenService)
        {
            this.applicationUserService = applicationUserService;
            this.shoppingTokenService = shoppingTokenService;
        }

        public ActionResult Consume(Guid id)
        {
            var shoppingToken = shoppingTokenService.Get(id);
            if (shoppingToken == null) return View(); // We really don't care

            var user = shoppingToken.ApplicationUser;
            user.LastWentShoppingAt = DateTime.Now;
            user.NextShoppingTripAt = applicationUserService.GetNextTripDate(user);

            // Since OWIN is so fucked up, we're relying on the commit from delete
            // to affect the user change.

            shoppingTokenService.Delete(id);

            return View();
        }
    }
}