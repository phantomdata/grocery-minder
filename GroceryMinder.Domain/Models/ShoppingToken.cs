using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Domain.Models
{
    public class ShoppingToken
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Index]
        public string ApplicationUserId { get; set; }

        [Required]
        public Guid Token { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
