using PhantomPurchases.Data;
using System;

namespace GroceryMinder.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
