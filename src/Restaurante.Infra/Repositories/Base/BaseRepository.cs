using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly RestaurantContext _context;

        public BaseRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }


        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null!,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
                                    string includeString = null!,
                                    bool disableTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
