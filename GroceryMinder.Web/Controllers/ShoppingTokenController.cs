using GroceryMinder.Service.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class ShoppingTokenController : BaseController
    {
        private readonly IShoppingTokenService shoppingTokenService;

        public ShoppingTokenController(IShoppingTokenService shoppingTokenService)
        {
            this.shoppingTokenService = shoppingTokenService;
        }

        public ActionResult Consume(Guid id)
        {
            shoppingTokenService.Delete(id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}