using GroceryMinder.Data.Repositories;
using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IGroceryCategoryService
    {
        void Create(GroceryCategory item);
        void Delete(GroceryCategory item);
        GroceryCategory Get(string userId, int itemId);
        IQueryable<GroceryCategory> GetAll(string userId);
        void Update(GroceryCategory item);
    }
    public class GroceryCategoryService : IGroceryCategoryService
    {
        private readonly IGroceryCategoryRepository groceryCategoryRepository;

        public GroceryCategoryService(IGroceryCategoryRepository groceryCategoryRepository)
        {
            this.groceryCategoryRepository = groceryCategoryRepository;
        }

        public void Create(GroceryCategory item)
        {
            groceryCategoryRepository.Add(item);
            groceryCategoryRepository.Commit();
            return;
        }

        public void Delete(GroceryCategory item)
        {
            groceryCategoryRepository.Delete(item);
            groceryCategoryRepository.Commit();
        }

        public GroceryCategory Get(string userId, int itemId)
        {
            var ret = groceryCategoryRepository.Get(x => x.ApplicationUserId == userId && x.GroceryCategoryId == itemId);
            return ret;
        }

        public IQueryable<GroceryCategory> GetAll(string userId)
        {
            var ret = groceryCategoryRepository.GetAll().Where(x => x.ApplicationUserId == userId);

            return ret;
        }

        public void Update(GroceryCategory item)
        {
            groceryCategoryRepository.Update(item);
            groceryCategoryRepository.Commit();
            return;
        }
    }
}
