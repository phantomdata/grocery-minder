using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhantomGroceries.Web.Models.GroceryItems
{
    public interface IFormViewModel
    {
        int GroceryItemId { get; set; }
        string Name { get; set; }
    }
}