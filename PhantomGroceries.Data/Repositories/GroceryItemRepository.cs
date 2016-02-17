using PhantomGroceries.Data.Infrastructure;
using PhantomGroceries.Domain.Models;

namespace PhantomGroceries.Data.Repositories
{
    public class GroceryItemRepository : RepositoryBase<GroceryItem>, IGroceryItemRepository
    {
        public GroceryItemRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IGroceryItemRepository : IRepository<GroceryItem>
    {

    }
}
