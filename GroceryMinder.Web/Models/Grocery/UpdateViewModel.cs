using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryMinder.Web.Models.Grocery
{
    public class UpdateViewModel : IFormViewModel
    {
        #region Properties
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must provide a category")]
        public int GroceryCategoryId { get; set; }

        [Display(Name="Last Purchased At")]
        [Required]
        public DateTime LastPurchasedAt { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name="Purchase Frequency")]
        public PurchaseFrequency PurchaseFrequency { get; set; }

        public IList<SelectListItem> AvailableGroceryCategories { get; set; }
        #endregion

        #region Constructors
        public UpdateViewModel() { }

        public UpdateViewModel(Domain.Models.Grocery groceryItem)
        {
            Id = groceryItem.Id;
            GroceryCategoryId = groceryItem.GroceryCategoryId;
            LastPurchasedAt = groceryItem.LastPurchasedAt;
            Name = groceryItem.Name;
            PurchaseFrequency = groceryItem.PurchaseFrequency;
        }
        #endregion

        #region Implementation
        public Domain.Models.Grocery UpdatedGroceryItem(Domain.Models.Grocery item)
        {
            item.GroceryCategoryId = this.GroceryCategoryId;
            item.LastPurchasedAt = this.LastPurchasedAt;
            item.Name = this.Name;
            item.PurchaseFrequency = this.PurchaseFrequency;

            return item;
        }
        #endregion
    }
}