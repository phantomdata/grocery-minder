using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Domain.Models
{
    public class Grocery
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Index]
        public string ApplicationUserId { get; set; }

        [ForeignKey("GroceryCategoryId")]
        public virtual GroceryCategory GroceryCategory { get; set; }

        [Index]
        [Required]
        public int GroceryCategoryId { get; set; }

        [Display(Name = "Average Cost")]
        [Required]
        public int AverageCost { get; set; }

        [Display(Name = "Last Purchased At")]
        [Required]
        public DateTime LastPurchasedAt { get; set; }

        [Display(Name = "Name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Display(Name="Next Purchase Date")]
        [Required]
        public DateTime NextPurchaseAt { get; set; }

        public PurchaseFrequency PurchaseFrequency { get; set; }
    }

    public enum PurchaseFrequency
    {
        [Display(Name = "Weekly")]
        Weekly,

        [Display(Name = "Every 2 Weeks")]
        EveryTwoWeeks,

        [Display(Name = "Every Month")]
        EveryMonth,

        [Display(Name = "Every 2 Months")]
        EveryTwoMonths
    }
}
