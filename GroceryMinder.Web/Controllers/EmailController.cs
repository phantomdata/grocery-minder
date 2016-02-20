using GroceryMinder.Domain.Models;
using GroceryMinder.Service.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public class EmailController : BaseController
    {
        private IApplicationUserService applicationUserService;
        private IEmailService emailService;
        private IGroceryListService groceryListService;
        private string rootUrl;
        private IShoppingTokenService shoppingTokenService;

        public EmailController(
            IApplicationUserService applicationUserService,
            IEmailService emailService, 
            IGroceryListService groceryListService,
            IShoppingTokenService shoppingTokenService
        )
        {
            this.applicationUserService = applicationUserService;

            var cfg = ConfigurationManager.AppSettings;
            emailService.Configure(cfg["smtpServer"], cfg["smtpPort"], cfg["smtpUsername"], cfg["smtpPassword"]);

            rootUrl = cfg["rootUrl"];
            this.emailService = emailService;
            this.groceryListService = groceryListService;
            this.shoppingTokenService = shoppingTokenService;
        }

        public ActionResult SendShoppingLists()
        {

            var users = applicationUserService.GetAll()
                .Where(x => x.NextShoppingTripAt <= DateTime.Now)
                .ToList(); // ToList() required to keep nested readers away

            foreach (var user in users)
            {
                var groceryList = groceryListService.Get(ApplicationUser, UserId);
                var shoppingToken = shoppingTokenService.Create(user.Id);

                // http://localhost:59439///ShoppingToken/Consume//a73897dc-cb22-4cc1-add4-85448eb3cd90
                var shoppingCompletionUrl = string.Format("{0}{1}{2}",
                    rootUrl,
                    "/ShoppingToken/Consume/",
                    shoppingToken.Token);

                emailService.SendShoppingList(user.Email, groceryList, shoppingCompletionUrl);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}