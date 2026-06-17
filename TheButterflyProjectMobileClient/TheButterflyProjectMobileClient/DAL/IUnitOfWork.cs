using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Models.Interface;

namespace TheButterflyProjectMobileClient.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, OfflineClientEntity;
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IRepository<T> Repository<T>() where T : class, OfflineClientEntity
        {
            var type = typeof(T);

            if (!_repositories.TryGetValue(type, out var repo))
            {
                repo = new EfRepository<T>(_db);
                _repositories[type] = repo;
            }

            return (IRepository<T>)repo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
            => await _db.SaveChangesAsync(ct);

        public void Dispose()
            => _db.Dispose();
    }
}
