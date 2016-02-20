using GroceryMinder.Data.Repositories;
using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IGroceryService
    {
        void Create(Grocery item);
        void Delete(Grocery item);
        Grocery Get(string userId, int itemId);
        IQueryable<Grocery> GetAll(string userId);
        void Update(Grocery item, bool autoCommit = false);
    }
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository groceryItemRepository;

        #region Public Methods
        public GroceryService(IGroceryRepository groceryItemRepository)
        {
            this.groceryItemRepository = groceryItemRepository;
        }

        public void Create(Grocery groceryItem)
        {
            groceryItem = updateNextPurchaseDate(groceryItem);
            groceryItemRepository.Add(groceryItem);
            groceryItemRepository.Commit();
            return;
        }

        public void Delete(Grocery item)
        {
            groceryItemRepository.Delete(item);
            groceryItemRepository.Commit();
        }

        public Grocery Get(string userId, int Id)
        {
            var ret = groceryItemRepository.Get(x => x.ApplicationUserId == userId && x.Id == Id);
            return ret;
        }

        public IQueryable<Grocery> GetAll(string userId)
        {
            var ret = groceryItemRepository.GetAll().Where(x => x.ApplicationUserId == userId);

            return ret;
        }

        public void Update(Grocery groceryItem, bool autoCommit = true)
        {
            groceryItem = updateNextPurchaseDate(groceryItem);
            groceryItemRepository.Update(groceryItem);
            if (autoCommit) groceryItemRepository.Commit();
            return;
        }
        #endregion

        #region Private Methods
        private Grocery updateNextPurchaseDate(Grocery grocery)
        {
            switch(grocery.PurchaseFrequency)
            {
                case PurchaseFrequency.Weekly:
                    grocery.NextPurchaseAt = grocery.LastPurchasedAt.AddDays(7);
                    break;
                case PurchaseFrequency.EveryTwoWeeks:
                    grocery.NextPurchaseAt = grocery.LastPurchasedAt.AddDays(14);
                    break;
                case PurchaseFrequency.EveryMonth:
                    grocery.NextPurchaseAt = grocery.LastPurchasedAt.AddMonths(1);
                    break;
                case PurchaseFrequency.EveryTwoMonths:
                    grocery.NextPurchaseAt = grocery.LastPurchasedAt.AddMonths(2);
                    break;
                default:
                    throw new Exception(string.Format("Invalid PurchaseFrequency ({0}) specified for grocery {1}.",
                        grocery.PurchaseFrequency, grocery.Name));  
            }

            return grocery;
        }
        #endregion
    }
}
