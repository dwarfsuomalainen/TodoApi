using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Dto;
using System.Security.Claims;

namespace TodoApi.Services
{

    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IHttpContextAccessor _context;

        public TodoService(ITodoRepository todoRepository, IHttpContextAccessor context)
        {
            _todoRepository = todoRepository;
            _context = context;
        }
        public async Task<Todo> GetTodo(int id)
        {
            var todo = await _todoRepository.Get(id);
            return (todo);

        }
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            var todos = await _todoRepository.GetAll();
            return (todos);
        }

        public async Task CreateTodo(CreateTodoDto createTodoDto)
        {
            var todo = new Todo
            {
                Name = createTodoDto.NameTodo,
                Description = createTodoDto.Description,
                UserId = 1,
                Created = DateTime.UtcNow,
                Status = "enum"
            };
            await _todoRepository.Add(todo);
        }

        public async Task DeleteTodo(int id)
        {
            await _todoRepository.Delete(id);

        }
        public async Task UpdateTodo(int id, UpdateTodoDto updateTodoDto)
        {

            var stringId = _context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (stringId is null || !int.TryParse(stringId, out int userId)) throw new UnauthorizedAccessException();

            var todo = await _todoRepository.GetByAuthId(userId, id);
            if (todo is null) throw new Exception(); // - Custom exception needed !!!

            todo.Name = updateTodoDto.NameTodo;
            todo.Description = updateTodoDto.Description;
            todo.Status = updateTodoDto.Status;
            todo.Updated = DateTime.UtcNow;
        }

    }
}

