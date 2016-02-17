using PhantomGroceries.Data.Infrastructure;
using PhantomGroceries.Domain.Models;

namespace PhantomGroceries.Data.Repositories
{
    public class RecurringPurchaseRepository : RepositoryBase<GroceryItem>, IRecurringPurchaseRepository
    {
        public RecurringPurchaseRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IRecurringPurchaseRepository : IRepository<GroceryItem>
    {

    }
}
