using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryItems
{
    public interface IFormViewModel
    {
        int GroceryItemId { get; set; }

        [Display(Name="Last Purchased On")]
        DateTime LastPurchasedAt { get; set; }

        string Name { get; set; }

        [Display(Name="Purchase Frequency")]
        PurchaseFrequency PurchaseFrequency { get; set; }
    }
}