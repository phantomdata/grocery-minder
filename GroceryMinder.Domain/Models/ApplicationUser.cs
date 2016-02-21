using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroceryMinder.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public virtual ICollection<GroceryCategory> GroceryCategories { get; set; }
        public virtual ICollection<Grocery> GroceryItems { get; set; }


        private DateTime? lastWentShoppingAt;
        [Required]
        public DateTime LastWentShoppingAt
        {
            get
            {
                if (lastWentShoppingAt == null)
                {
                    lastWentShoppingAt = DateTime.Now;
                }
                return lastWentShoppingAt.Value;
            }
            set { lastWentShoppingAt = value; }
        }

        private DateTime? nextShoppingTripAt;
        [Required]
        public DateTime NextShoppingTripAt
        {
            get
            {
                if (nextShoppingTripAt == null)
                {
                    nextShoppingTripAt = DateTime.Now;
                }
                return nextShoppingTripAt.Value;
            }
            set { nextShoppingTripAt = value; }
        }
    }
}
