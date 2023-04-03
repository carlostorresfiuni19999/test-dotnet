using Microsoft.EntityFrameworkCore;

namespace TestEx.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
    }
}
