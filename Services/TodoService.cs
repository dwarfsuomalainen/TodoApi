using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Dto;

namespace TodoApi.Services
{
   
    public class TodoService: ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
           _todoRepository = todoRepository; 
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
        NameTodo = createTodoDto.NameTodo,
        Description = createTodoDto.Description,
        UserId = createTodoDto.UserId,
        DateCreated = createTodoDto.DateCreated,
        Status = createTodoDto.Status
        };
        await _todoRepository.Add(todo);
    }

    public async Task DeleteTodo(int id)
    {
        await _todoRepository.Delete(id);

    }
    public async Task UpdateTodo(int id, UpdateTodoDto updateTodoDto)
    {
        Todo todo = new()
        {
        TodoId = id,
        NameTodo = updateTodoDto.NameTodo,
        Description = updateTodoDto.Description,
        DateUpdated = updateTodoDto.DateUpdated,
        Status = updateTodoDto.Status
        };

        await _todoRepository.Update(todo);
    }
  }
}

