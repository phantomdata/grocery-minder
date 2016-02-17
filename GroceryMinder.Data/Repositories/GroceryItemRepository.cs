using GroceryMinder.Data.Infrastructure;
using GroceryMinder.Domain.Models;

namespace GroceryMinder.Data.Repositories
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
