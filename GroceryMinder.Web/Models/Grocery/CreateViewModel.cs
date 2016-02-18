using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.Grocery
{
    public class CreateViewModel : IFormViewModel
    {
        #region Properties
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

        #region Implementation
        public Domain.Models.Grocery ToGroceryItem()
        {
            var ret = new Domain.Models.Grocery()
            {
                LastPurchasedAt = this.LastPurchasedAt,
                Name = this.Name,
                PurchaseFrequency = this.PurchaseFrequency
            };

            return ret;
        }
        #endregion
    }
}