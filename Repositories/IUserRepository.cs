using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    public User? FindByEmail(string email);

    bool CheckIsUserExistByEmail(string email);
    }
}