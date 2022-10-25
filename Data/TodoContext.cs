using System.Threading;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public interface TodoContext
    {
        DbSet<Todo> Todos {get; set;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}