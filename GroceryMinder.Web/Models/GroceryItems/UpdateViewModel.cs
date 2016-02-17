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

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        #endregion

        #region Constructors
        public UpdateViewModel() { }

        public UpdateViewModel(GroceryItem groceryItem)
        {
            GroceryItemId = groceryItem.GroceryItemId;
            Name = groceryItem.Name;
        }
        #endregion

        #region Implementation
        public GroceryItem UpdatedGroceryItem(GroceryItem item)
        {
            item.Name = this.Name;

            return item;
        }
        #endregion
    }
}