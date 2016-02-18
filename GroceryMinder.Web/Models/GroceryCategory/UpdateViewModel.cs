using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryCategory
{
    public class UpdateViewModel : IFormViewModel
    {
        #region Properties
        [Required]
        public int GroceryCategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        #endregion

        #region Constructors
        public UpdateViewModel() { }

        public UpdateViewModel(Domain.Models.GroceryCategory item)
        {
            GroceryCategoryId = item.GroceryCategoryId;
            Name = item.Name;
        }
        #endregion

        #region Implementation
        public Domain.Models.GroceryCategory UpdatedGroceryCategory(Domain.Models.GroceryCategory item)
        {
            item.Name = this.Name;

            return item;
        }
        #endregion
    }
}