using GroceryMinder.Service.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class ApplicationUserController : BaseController
    {
        private readonly IApplicationUserService applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;
        }

        /// <summary>
        /// Yes, I feel dirty that the controller is doing this.  OWIN is
        /// too far integrated into ASP.NET for my liking.
        /// </summary>
        /// <param name="LastWentShoppingAt"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateLastWentShoppingAt(DateTime LastWentShoppingAt)
        {
            var user = ApplicationUser;
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            user.LastWentShoppingAt = LastWentShoppingAt;
            user.NextShoppingTripAt = applicationUserService.GetNextTripDate(user);

            var result = manager.UpdateAsync(user).Result;
            

            // The following is currently the only place this form is POSTed from.
            return RedirectToAction("Index", "GroceryList");
        }
    }
}