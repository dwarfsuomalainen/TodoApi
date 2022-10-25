using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public interface TodoContext: DbContext
    {
        DbSet<Todo> Todos {get; init;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}