using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Dto;


namespace TodoApi.Controllers.v1
{
    [ApiController]
    //[Authorize]
    [Route("api/v{version:apiVersion}/todos")]
    [ApiVersion("1")]
    public class TodoController: ControllerBase 
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
           _todoService = todoService; 
        }
    [HttpGet("{id}")]    
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _todoService.GetTodo(id);
        if(todo == null)
            return NotFound();
        
        return Ok(todo);

    }        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        var todos = await _todoService.GetTodos();
        return Ok(todos);
    }
    [HttpPost]

    public async Task<ActionResult> CreateTodo(CreateTodoDto createTodoDto)
    {
        await _todoService.CreateTodo(createTodoDto);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        await _todoService.DeleteTodo(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTodo(int id, UpdateTodoDto updateTodoDto)
    {
        await _todoService.UpdateTodo(id, updateTodoDto);
        return Ok();

    }
    }
}