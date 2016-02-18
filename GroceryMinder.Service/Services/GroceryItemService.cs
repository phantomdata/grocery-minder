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
        void Create(GroceryItem groceryItem);
        void Delete(GroceryItem item);
        GroceryItem Get(string userId, int groceryItemId);
        IQueryable<GroceryItem> GetAll(string userId);
        void Update(GroceryItem groceryItem);
    }
    public class GroceryItemService : IGroceryItemService
    {
        private readonly IGroceryItemRepository groceryItemRepository;

        public GroceryItemService(IGroceryItemRepository groceryItemRepository)
        {
            this.groceryItemRepository = groceryItemRepository;
        }

        public void Create(GroceryItem groceryItem)
        {
            groceryItemRepository.Add(groceryItem);
            groceryItemRepository.Commit();
            return;
        }

        public void Delete(GroceryItem item)
        {
            groceryItemRepository.Delete(item);
            groceryItemRepository.Commit();
        }

        public GroceryItem Get(string userId, int groceryItemId)
        {
            var ret = groceryItemRepository.Get(x => x.ApplicationUserId == userId && x.GroceryItemId == groceryItemId);
            return ret;
        }

        public IQueryable<GroceryItem> GetAll(string userId)
        {
            var ret = groceryItemRepository.GetAll().Where(x => x.ApplicationUserId == userId);

            return ret;
        }

        public void Update(GroceryItem groceryItem)
        {
            groceryItemRepository.Update(groceryItem);
            groceryItemRepository.Commit();
            return;
        }
    }
}
