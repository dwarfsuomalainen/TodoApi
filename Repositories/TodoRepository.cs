using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Enums;

namespace TodoApi.Repositories
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        
        public TodoRepository(ITodoContext context) : base(context, context.Todos){}
        public async Task Add(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var todoToDelete = await _context.Todos.FindAsync(id);
            if (todoToDelete == null)
                throw new NullReferenceException();
            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
        }

       /* public async Task<Todo> Get(int id)
        {
            return await _context.Todos.FindAsync(id);
        }*/

        /*public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _context.Todos.ToListAsync();
        }*/

        public async Task<Todo?> GetByAuthId(int todoId, int userId)
        {
            return _dbSet.FirstOrDefault(x => x.UserId == userId  && x.Id == todoId);
        }

            public async Task<Todo[]> GetTodos(int userId, TodoStatus? status) // - ? nullable status 
        {
            return _dbSet.Where(x => x.UserId == userId && status.HasValue ? x.Status == status.Value: true ).ToArray(); // -returnin an array 
        }
        
        
        public async Task Update(Todo todo)
        {
            var todoToUpdate = await _context.Todos.FindAsync(todo.Id);
            if (todoToUpdate == null)
                throw new NullReferenceException();

            todoToUpdate.Name = todo.Name;
            todoToUpdate.Description = todo.Description;
            todoToUpdate.Updated = todo.Updated;
            todoToUpdate.Status = todo.Status;
            await _context.SaveChangesAsync();
        }
    }
}