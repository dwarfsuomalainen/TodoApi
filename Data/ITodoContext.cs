using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public interface ITodoContext
    {
        DbSet<Todo>? Todos { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<User> Users { get; init; }
    }
}