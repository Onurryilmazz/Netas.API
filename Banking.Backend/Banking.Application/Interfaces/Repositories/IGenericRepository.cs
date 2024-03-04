using System.Linq.Expressions;

namespace Banking.Application.Interfaces.Repositories;

public interface IGenericRepository<T, A> where A : class where T : class
{
    Task<A> GetByIdAsync(int id);
    Task<IQueryable<A>> GetAllAsync();
    Task<List<A>> GetWhereAsync(Expression<Func<T,bool>> method);
    Task<A> GetSingleAsync(Expression<Func<T,bool>> method);
    Task<A> GetIncludeAsync(Expression<Func<T, bool>> method, Expression<Func<T, object>> include);
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    Task<bool> UpdateAsync(T entity);
    Task<bool> UpdateRangeAsync(List<T> entities);
    Task<bool> DeleteAsync(T entity);
}