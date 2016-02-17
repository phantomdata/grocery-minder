using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryItems
{
    public interface IFormViewModel
    {
        int GroceryItemId { get; set; }
        string Name { get; set; }
    }
}