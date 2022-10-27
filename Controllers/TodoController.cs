using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Dto;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController: ControllerBase 
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
           _todoRepository = todoRepository; 
        }
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _todoRepository.Get(id);
        if(todo == null)
            return NotFound();
        
        return Ok(todo);

    }        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        var todos = await _todoRepository.GetAll();
        return Ok(todos);
    }
    [HttpPost]

    public async Task<ActionResult> CreateTodo(CreateTodoDto createTodoDto)
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
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        await _todoRepository.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTodo(int id, UpdateTodoDto updateTodoDto)
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
        return Ok();

    }
    }
}