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
        private readonly IGroceryListService groceryListService;

        public GroceryListController(IApplicationUserService applicationUserService, IGroceryListService groceryListService)
        {
            this.applicationUserService = applicationUserService;
            this.groceryListService = groceryListService;
        }

        public ActionResult Index()
        {
            var nextTripDate = ApplicationUser.NextShoppingTripAt;
            var groceryList = groceryListService.Get(ApplicationUser, UserId);

            var vm = new Models.GroceryList.Index()
            {
                GroceryList = groceryList,
                LastWentShoppingAt = ApplicationUser.LastWentShoppingAt
            };

            return View(vm);
        }
    }
}