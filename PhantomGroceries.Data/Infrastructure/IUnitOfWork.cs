namespace PhantomGroceries.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
