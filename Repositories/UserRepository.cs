using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    public UserRepository(TodoContext dbContext) : base(dbContext, dbContext.Users) { }

    public User? FindByEmail(string email)
    {
        return this._dbSet.FirstOrDefault(user => user.Email == email.ToLower());
    }

    public bool CheckIsUserExistByEmail(string email)
    {
        return this._dbSet.Any(user => user.Email == email.ToLower());
    }

    public async Task UpdateUserPassword(int userId, string passwordHash) 
    {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception(); // - Custom exception needed!!!
            user.Password = passwordHash;
            user.Updated = DateTime.UtcNow; 
            await _context.SaveChangesAsync();
    }
    }
}