using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
            protected readonly DbSet<T> _dbSet;
            protected readonly ITodoContext _context;
    
    public BaseRepository(ITodoContext dbContext, DbSet<T> dbSet)
    {
        _context = dbContext;
        _dbSet = dbSet;
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<T?> FindById(int Id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == Id);
    }

    public async Task Add(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
    }
}