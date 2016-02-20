using GroceryMinder.Data.Repositories;
using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IShoppingTokenService
    {
        ShoppingToken Create(string applicationUserId);
        ShoppingToken Get(Guid token);
        void Delete(Guid id);
    }
    public class ShoppingTokenService : IShoppingTokenService
    {
        private readonly IShoppingTokenRepository shoppingTokenRepository;

        public ShoppingTokenService(IShoppingTokenRepository shoppingTokenRepository)
        {
            this.shoppingTokenRepository = shoppingTokenRepository;
        }

        public ShoppingToken Create(string applicationUserId)
        {
            var shoppingToken = new ShoppingToken()
            {
                ApplicationUserId = applicationUserId,
                ExpiresAt = DateTime.Now.AddDays(14),
                Token = Guid.NewGuid()
            };

            shoppingTokenRepository.Add(shoppingToken);
            shoppingTokenRepository.Commit();

            return shoppingToken;
        }

        public void Delete(Guid token)
        {
            var item = shoppingTokenRepository.Get(x => x.Token.Equals(token));
            if (item == null) return;

            shoppingTokenRepository.Delete(item);
            shoppingTokenRepository.Commit();
        }

        public ShoppingToken Get(Guid token)
        {
            var item = shoppingTokenRepository.Get(x => x.Token.Equals(token));
            return item;
        }
    }
}
