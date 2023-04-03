using System.Linq.Expressions;
using TestEx.Models;
using TestEx.Repository;

namespace TestEx.Services
{
    public class TodoService : ITodoRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _db;

        public TodoService(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        

        public async Task<Todo> AddOrUpdateAsync(Todo t)
        {

            var result = await _db.Todos.AddAsync(t);
            await this.SaveAsync();
            return result.Entity;
        }

        public async Task<Todo> ChangeStatusAsync(Todo T)
        {
            T.IsActive = !T.IsActive;
            await this.SaveAsync();
            return T;
        }

        public async Task<bool> Delete(Todo t)
        {
            try
            {
                _db.Todos.Remove(t);
                await _db.SaveChangesAsync();
                return true;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
     
        }

        public IEnumerable<Todo> GetAll()
        {
            return _db.Todos;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~TodoService()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<Todo> FindByIdAsync(int id)
        {
            var query = await _db.Todos.FindAsync(id);
            if (null == query) Console.WriteLine($"No existe el User con Id: {id}");
            return query;
        }

        public bool ExistAnyById(int id)
        {
            return _db.Todos
                .Any(t => t.Id == id);
        }
    }
}
