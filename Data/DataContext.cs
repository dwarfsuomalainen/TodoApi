using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public class DataContext: DbContext, TodoContext
    {
        public DataContext(DbContextOption<DataContext> options): base(options) 
        {

        }

        public DbSet<TodoApi> Todos {get; set;}
        
    }
}