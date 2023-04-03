using TestEx.Models;

namespace TestEx.Repository
{
    public interface ITodoRepository : ICrudRepository<Todo>
    {
        Task<Todo> ChangeStatusAsync(Todo T);

    }
}
