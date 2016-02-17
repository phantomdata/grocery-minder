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
        IEnumerable<GroceryItem> GetAll(string userId);
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
            return;
        }

        public IEnumerable<GroceryItem> GetAll(string userId)
        {
            var ret = groceryItemRepository.GetAll();

            return ret;
        }
    }
}
