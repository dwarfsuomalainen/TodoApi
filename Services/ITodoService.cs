using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Dto;
using TodoApi.Enums;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        /*Task<Todo> GetTodo(int id);*/
        Task<IEnumerable<Todo>> GetTodos(TodoStatus? status);
        Task CreateTodo(CreateTodoDto createTodoDto);
        Task DeleteTodo(int id);
        Task UpdateTodo(int id, UpdateTodoDto updateTodoDto);
    }
}
