using PhantomPurchases.Data;
using System;

namespace PhantomGroceries.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
