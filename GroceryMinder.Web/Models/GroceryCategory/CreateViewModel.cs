using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryMinder.Web.Models.GroceryCategory
{
    public class CreateViewModel : IFormViewModel
    {
        #region Properties
        public int GroceryCategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Priority { get; set; }
        #endregion

        #region Implementation
        public Domain.Models.GroceryCategory ToGroceryCategory()
        {
            var ret = new Domain.Models.GroceryCategory()
            {
                Name = this.Name,
                Priority = this.Priority
            };

            return ret;
        }
        #endregion
    }
}