using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.DAL
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(params object[] keyValues);
        Task<IEnumerable<T>> GetAllAsync();
        IAsyncEnumerable<T> GetAllEnumerableAsync();

        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> FindEnumerableAsync(Expression<Func<T, bool>> predicate);
    }
    public class EfRepository<T> : IRepository<T>
    where T : class, OfflineClientEntity
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _set;

        public EfRepository(AppDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public async Task<T?> GetByIdAsync(params object[] keyValues)
            => await _set.FindAsync(keyValues);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _set.Where(e => !e.Deleted).ToListAsync();

        public IAsyncEnumerable<T> GetAllEnumerableAsync()
            => _set.Where(e => !e.Deleted).AsAsyncEnumerable();

        public async Task<T> AddAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            await _set.AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            _set.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            _set.Update(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _set.Where(predicate).ToListAsync();
        public IAsyncEnumerable<T> FindEnumerableAsync(Expression<Func<T, bool>> predicate)
            => _set.Where(predicate).AsAsyncEnumerable();
    }
