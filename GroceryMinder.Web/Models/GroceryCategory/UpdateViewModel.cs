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
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Priority { get; set; }
        #endregion

        #region Constructors
        public UpdateViewModel() { }

        public UpdateViewModel(Domain.Models.GroceryCategory item)
        {
            Id = item.Id;
            Name = item.Name;
            Priority = item.Priority;
        }
        #endregion

        #region Implementation
        public Domain.Models.GroceryCategory UpdatedGroceryCategory(Domain.Models.GroceryCategory item)
        {
            item.Name = this.Name;
            item.Priority = this.Priority;

            return item;
        }
        #endregion
    }
}