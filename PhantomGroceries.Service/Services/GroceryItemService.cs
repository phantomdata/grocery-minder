using PhantomGroceries.Data.Repositories;
using PhantomGroceries.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomGroceries.Service.Services
{
    public interface IGroceryItemService
    {
        void Create(GroceryItem groceryItem);
        GroceryItem Get(string userId, int groceryItemId);
        IEnumerable<GroceryItem> GetAll(string userId);
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

        public GroceryItem Get(string userId, int groceryItemId)
        {
            var ret = groceryItemRepository.Get(x => x.ApplicationUserId == userId && x.GroceryItemId == groceryItemId);
            return ret;
        }

        public IEnumerable<GroceryItem> GetAll(string userId)
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
