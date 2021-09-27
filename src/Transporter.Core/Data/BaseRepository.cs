using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transporter.Core.DomainObjects;

namespace Transporter.Core.Data
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TEntity> FindById(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IQueryable<TEntity> FindByWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var result = _dbSet.Where(query).AsQueryable();

            foreach (var i in includes)
            {
                result = result.Include(i);
            }

            return result;
        }

        public async Task<bool> SaveChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
