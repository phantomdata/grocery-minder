using GroceryMinder.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Controllers
{
    public partial class BaseController : Controller
    {
        private string _userId { get; set; } // Not meant to be used beyond following scope
        public string UserId
        {
            get
            {
                if (_userId == null)
                {
                    _userId = User.Identity.GetUserId();
                }
                return _userId;
            }
        }

        private ApplicationUser _applicationUser { get; set; }
        public ApplicationUser ApplicationUser
        {
            get
            {
                if (_applicationUser == null)
                {
                    _applicationUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                }
                return _applicationUser;
            }
        }
    }
}