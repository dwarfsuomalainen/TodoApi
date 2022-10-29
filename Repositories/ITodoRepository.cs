using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> Get(int id);
        Task<IEnumerable<Todo>> GetAll();
        Task Add(Todo todo);
        Task Delete(int id);
        Task Update(Todo todo);
    }
}