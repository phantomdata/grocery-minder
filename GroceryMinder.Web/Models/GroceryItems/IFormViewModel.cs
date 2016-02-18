using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryItems
{
    public interface IFormViewModel
    {
        int GroceryItemId { get; set; }

        DateTime LastPurchasedAt { get; set; }
        string Name { get; set; }
        PurchaseFrequency PurchaseFrequency { get; set; }
    }
}