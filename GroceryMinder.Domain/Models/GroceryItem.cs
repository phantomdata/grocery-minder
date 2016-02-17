using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Domain.Models
{
    public class GroceryItem
    {
        [Key]
        public int GroceryItemId { get; set; }

        [Index]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
