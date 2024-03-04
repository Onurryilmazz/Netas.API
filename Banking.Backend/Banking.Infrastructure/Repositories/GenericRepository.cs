using System.Linq.Expressions;
using Banking.Application.Interfaces.Repositories;
using Banking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Banking.Infrastructure.Repositories;

public class GenericRepository<T, A> : IGenericRepository<T, A> where T : class where A : class
    {
        protected readonly BankingDataContext _context;
        private readonly DbSet<T> _dbSet;
        
        public GenericRepository(BankingDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<IQueryable<A>> GetAllAsync()
        {
            var response = _dbSet.Select(x => x as A);
            return response;
        }

        public async Task<A> GetByIdAsync(int id)
        {
            var response = await _dbSet.FindAsync(id) as A;
            return response;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<bool> UpdateRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            _dbSet.UpdateRange(entities);
            return true;
        }
        public async Task<A> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            var response = await _dbSet.FirstOrDefaultAsync(method) as A;
            return response;
        }

        public async Task<List<A>> GetWhereAsync(Expression<Func<T, bool>> method)
        {
            var response = await _dbSet.Where(method).Select(x => x as A).ToListAsync();
            return response;
        }

        public async Task<A> GetIncludeAsync(Expression<Func<T, bool>> method, Expression<Func<T, object>> include)
        {
            var response = await _dbSet.Include(include).FirstOrDefaultAsync(method) as A;
            return response;
        }

    }