using TodoApi.Models;
using TodoApi.Enums;

namespace TodoApi.Repositories
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {
        /*Task<Todo> Get(int id); // - this feature for the future version **
        Task<IEnumerable<Todo>> GetAll();*/
        Task Add(Todo todo);
        Task Delete(int id);
        Task<Todo[]> GetTodos(int userId, TodoStatus? status);
        Task<Todo?> GetByAuthId(int todoId, int userId);
        Task Update(Todo todo);
    }
}