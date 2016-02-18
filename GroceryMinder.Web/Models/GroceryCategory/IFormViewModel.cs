using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryCategory
{
    public interface IFormViewModel
    {
        int GroceryCategoryId { get; set; }

        string Name { get; set; }
    }
}