using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? FindByEmail(string email);

        bool CheckIsUserExistByEmail(string email);

        Task UpdateUserPassword(int userId, string passwordHash);
    }
}