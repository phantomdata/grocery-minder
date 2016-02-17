using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomGroceries.Domain.Models
{
    public class GroceryItem
    {
        [Key]
        public int GroceryItemID { get; set; }

        [Display(Name = "Name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
