using TodoApi.Models;
using TodoApi.Data;


namespace TodoApi.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<IQueryable<T>> GetAll();
        Task<T?> FindById(int Id);
        Task Add(T entity);
        Task Delete(T entity);

    }
}