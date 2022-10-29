using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public abstract class BaseRepositiory<T> : IBaseRepository<T> where T : Base
    {
            protected readonly DbSet<T> _dbSet;

    public BaseRepository(TodoContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public T? FindById(Id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    }
}