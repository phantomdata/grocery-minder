﻿using GroceryMinder.Data.Infrastructure;
using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Data.Repositories
{
    public class ShoppingTokenRepository : RepositoryBase<ShoppingToken>, IShoppingTokenRepository
    {
        public ShoppingTokenRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IShoppingTokenRepository : IRepository<ShoppingToken>
    {

    }
}
