namespace TestEx.Repository
{
    public interface ICrudRepository<T> : IDisposable where T : class
    {
        Task<T> AddOrUpdateAsync(T t);
        Task<bool> Delete(T t);
        IEnumerable<T> GetAll();
        Task SaveAsync();
        Task<T> FindByIdAsync(int id);
        bool ExistAnyById(int id);

    }
}
