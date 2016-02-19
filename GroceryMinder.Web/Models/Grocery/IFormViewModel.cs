using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Models.Grocery
{
    public interface IFormViewModel
    {
        int Id { get; set; }

        [Display(Name="Average Cost")]
        [Required]
        int AverageCost { get; set; }

        [Display(Name="Last Purchased On")]
        DateTime LastPurchasedAt { get; set; }

        [Display(Name="Grocery Category")]
        int GroceryCategoryId { get; set; }

        string Name { get; set; }

        [Display(Name="Purchase Frequency")]
        PurchaseFrequency PurchaseFrequency { get; set; }

        IList<SelectListItem> AvailableGroceryCategories { get; set; }
    }
}