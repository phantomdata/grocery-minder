using GroceryMinder.Data.Repositories;
using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IGroceryItemService
    {
        void Create(Grocery groceryItem);
        void Delete(Grocery item);
        Grocery Get(string userId, int groceryItemId);
        IQueryable<Grocery> GetAll(string userId);
        void Update(Grocery groceryItem);
    }
    public class GroceryItemService : IGroceryItemService
    {
        private readonly IGroceryItemRepository groceryItemRepository;

        public GroceryItemService(IGroceryItemRepository groceryItemRepository)
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
