using GroceryMinder.Data.Infrastructure;
using GroceryMinder.Domain.Models;

namespace GroceryMinder.Data.Repositories
{
    public class GroceryRepository : RepositoryBase<Grocery>, IGroceryRepository
    {
        public GroceryRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }

    public interface IGroceryRepository : IRepository<Grocery>
    {

    }
}
