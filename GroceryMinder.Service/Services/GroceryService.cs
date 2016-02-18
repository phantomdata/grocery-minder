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
        void Update(Grocery item);
    }
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository groceryItemRepository;

        public GroceryService(IGroceryRepository groceryItemRepository)
        {
            this.groceryItemRepository = groceryItemRepository;
        }

        public void Create(Grocery groceryItem)
        {
            groceryItemRepository.Add(groceryItem);
            groceryItemRepository.Commit();
            return;
        }

        public void Delete(Grocery item)
        {
            groceryItemRepository.Delete(item);
            groceryItemRepository.Commit();
        }

        public Grocery Get(string userId, int groceryItemId)
        {
            var ret = groceryItemRepository.Get(x => x.ApplicationUserId == userId && x.GroceryItemId == groceryItemId);
            return ret;
        }

        public IQueryable<Grocery> GetAll(string userId)
        {
            var ret = groceryItemRepository.GetAll().Where(x => x.ApplicationUserId == userId);

            return ret;
        }

        public void Update(Grocery groceryItem)
        {
            groceryItemRepository.Update(groceryItem);
            groceryItemRepository.Commit();
            return;
        }
    }
}
