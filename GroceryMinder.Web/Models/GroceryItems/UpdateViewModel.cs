using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryItems
{
    public class UpdateViewModel : IFormViewModel
    {
        #region Properties
        [Required]
        public int GroceryItemId { get; set; }

        [Display(Name="Last Purchased At")]
        [Required]
        public DateTime LastPurchasedAt { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name="Purchase Frequency")]
        public PurchaseFrequency PurchaseFrequency { get; set; }
        #endregion

        #region Constructors
        public UpdateViewModel() { }

        public UpdateViewModel(Grocery groceryItem)
        {
            GroceryItemId = groceryItem.GroceryItemId;
            LastPurchasedAt = groceryItem.LastPurchasedAt;
            Name = groceryItem.Name;
            PurchaseFrequency = groceryItem.PurchaseFrequency;
        }
        #endregion

        #region Implementation
        public Grocery UpdatedGroceryItem(Grocery item)
        {
            item.LastPurchasedAt = this.LastPurchasedAt;
            item.Name = this.Name;
            item.PurchaseFrequency = this.PurchaseFrequency;

            return item;
        }
        #endregion
    }
}