using System.Linq.Expressions;
using TestCase.Domain;
using TestCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestCase.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _entities;

        protected GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool isActive = true)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id && s.IsActive == isActive);
        }

        public async Task<List<TEntity>> AllAsync(bool isActive = true)
        {
            return await _entities.Where(s => s.IsActive == isActive).AsQueryable().ToListAsync();
        }

        public async Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive == isActive).ToListAsync();
        }

        public async Task SaveAsync(TEntity entity)
        {
            try
            {
                await _entities.AddAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = _entities.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive == isActive).CountAsync();
        }

        public void Delete(TEntity entity)
        {
            entity.SetIsActive(false);
        }
    }