using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoContext _context;
    

        public TodoRepository(ITodoContext context) 
        {
            _context = context;
        }
        public async Task Add(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}