/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    TodoModel[] GetAll(TodoStatus? status = null);
    TodoModel Create(CreateTodoModel payload);
    TodoModel Update(Guid id, UpdateTodoModel payload);
    void Delete(Guid id);
}

public class TodoService : ITodoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserProvider _userProvider;
    private readonly ILogger<TodoService> _logger;

    public TodoService(
        IUnitOfWork unitOfWork,
        IUserProvider userProvider,
        ILogger<TodoService> logger)
    {
        _unitOfWork = unitOfWork;
        _userProvider = userProvider;
        _logger = logger;
    }

    public TodoModel[] GetAll(TodoStatus? status = null)
    {
        var userId = _userProvider.GetUserId();
        var todos = _unitOfWork.Todos.GetUserTodos(userId, status);
        return todos.Select(MapEntityToModel).ToArray();
    }

    public TodoModel Create(CreateTodoModel payload)
    {
        var userId = _userProvider.GetUserId();

        var todo = new TodoEntity
        {
            Name = payload.Name,
            Description = payload.Description,
            UserId = userId,
        };

        _unitOfWork.Todos.Add(todo);
        _unitOfWork.SaveChanges();

        return MapEntityToModel(todo);
    }

    public TodoModel Update(Guid id, UpdateTodoModel payload)
    {
        var userId = _userProvider.GetUserId();

        var todo = _unitOfWork.Todos.FindUserTodoById(userId, id);
        if (todo is null) throw new EntityNotFoundException();

        todo.Name = payload.Name;
        todo.Description = payload.Description;
        todo.Status = payload.Status;
        todo.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.SaveChanges();

        return MapEntityToModel(todo);
    }

    public void Delete(Guid id)
    {
        var userId = _userProvider.GetUserId();

        var todo = _unitOfWork.Todos.FindUserTodoById(userId, id);
        if (todo is null) throw new EntityNotFoundException();

        _unitOfWork.Todos.Delete(todo);
        _unitOfWork.SaveChanges();
    }

    private TodoModel MapEntityToModel(TodoEntity entity) => new TodoModel
    {
        CreatedAt = entity.CreatedAt,
        Description = entity.Description,
        Id = entity.Id,
        Name = entity.Name,
        Status = entity.Status,
        UpdatedAt = entity.UpdatedAt
    };
}*/