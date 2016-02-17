using PhantomGroceries.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhantomGroceries.Web.Models.GroceryItems
{
    public class CreateViewModel : IFormViewModel
    {
        #region Properties
        public int GroceryItemId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        #endregion

        #region Implementation
        public GroceryItem ToGroceryItem()
        {
            var ret = new GroceryItem()
            {
                Name = this.Name
            };

            return ret;
        }
        #endregion
    }
}