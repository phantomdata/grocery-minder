using Microsoft.AspNet.Identity;
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
    }
}