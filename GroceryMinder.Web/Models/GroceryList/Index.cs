using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryList
{
    public class Index
    {
        public IList<Domain.Models.Grocery> GroceryList { get; set; }
    }
}