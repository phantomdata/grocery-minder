using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IApplicationUserService
    {
        DateTime GetNextTripDate(ApplicationUser applicationUser);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        public DateTime GetNextTripDate(ApplicationUser applicationUser)
        {
            DateTime nextTripDate;

            // If its been awhile since they went shopping...
            if (applicationUser.LastWentShoppingAt < DateTime.Now.AddDays(-7) || applicationUser.LastWentShoppingAt > DateTime.Now)
            {
                nextTripDate = DateTime.Now;
            }
            // Otherwise, normal schedule
            else {
                nextTripDate = applicationUser.LastWentShoppingAt.AddDays(7); // Assume a weekly trip for now
            }

            return nextTripDate;
        }
    }
}
