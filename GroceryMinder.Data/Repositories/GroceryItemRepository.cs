using GroceryMinder.Data.Infrastructure;
using GroceryMinder.Domain.Models;

namespace GroceryMinder.Data.Repositories
{
    public class GroceryItemRepository : RepositoryBase<Grocery>, IGroceryItemRepository
    {
        public GroceryItemRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IGroceryItemRepository : IRepository<Grocery>
    {

    }
}
