using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;


namespace TodoApi.Repositories
{
    public interface IBaseRepository<T> where T: Base
    {
        T? FindById(Id);
        void Add(T entity);
        void Delete(T entity);

    }
}