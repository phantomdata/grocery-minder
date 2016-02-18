using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryCategory
{
    public interface IFormViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        int Priority { get; set; }
    }
}