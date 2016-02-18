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

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Index]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Last Purchased At")]
        [Required]
        public DateTime LastPurchasedAt { get; set; }

        [Display(Name = "Name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        public PurchaseFrequency PurchaseFrequency { get; set; }
    }

    public enum PurchaseFrequency
    {
        Weekly,
        EveryTwoWeeks,
        EveryMonth,
        EveryTwoMonths
    }
}
