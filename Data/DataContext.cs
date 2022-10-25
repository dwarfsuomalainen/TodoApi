
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
 
namespace TodoApi.Data
{
    public class DataContext: DbContext, TodoContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options);
    }
    public DbSet<Todo> Todos {get; init;}
}