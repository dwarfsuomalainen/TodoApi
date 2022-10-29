using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var todoToDelete = await _context.Todos.FindAsync(id);
            if (todoToDelete == null)
                throw new NullReferenceException();
            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> Get(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task Update(Todo todo)
        {
            var todoToUpdate = await _context.Todos.FindAsync(todo.TodoId);
            if (todoToUpdate == null)
                throw new NullReferenceException();

            todoToUpdate.NameTodo = todo.NameTodo;
            todoToUpdate.Description = todo.Description;
            todoToUpdate.DateUpdated = todo.DateUpdated;
            todoToUpdate.Status = todo.Status;
            await _context.SaveChangesAsync();
        }
    }
}