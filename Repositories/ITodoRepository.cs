using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {
        Task<Todo> Get(int id);
        Task<IEnumerable<Todo>> GetAll();
        Task Add(Todo todo);
        Task Delete(int id);
        Task<Todo?> GetByAuthId(int todoId, int userId);
        Task Update(Todo todo);
    }
}