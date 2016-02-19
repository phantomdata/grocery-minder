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
        [HttpPost]
        public ActionResult UpdateLastWentShoppingAt(DateTime LastWentShoppingAt)
        {
            var user = ApplicationUser;
            var owin = System.Web.HttpContext.Current.GetOwinContext();
            var manager = owin.GetUserManager<ApplicationUserManager>();

            user.LastWentShoppingAt = LastWentShoppingAt;

            var result = manager.UpdateAsync(user).Result;
            

            // The following is currently the only place this form is POSTed from.
            return RedirectToAction("Index", "GroceryList");
        }
    }
}