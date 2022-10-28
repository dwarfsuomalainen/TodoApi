
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
 
namespace TodoApi.Data
{
    public class TodoContext: DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options){}
        public DbSet<Todo>? Todos {get; init;}

        
    }
    
}