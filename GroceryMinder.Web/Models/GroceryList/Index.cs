using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryList
{
    public class Index
    {
        public Domain.Models.GroceryList GroceryList { get; set; }
        public DateTime LastWentShoppingAt { get; set; }
    }
}