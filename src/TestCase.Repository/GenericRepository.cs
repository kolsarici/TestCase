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

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id && s.IsActive, cancellationToken: cancellationToken);
        }

        public async Task<List<TEntity>> AllAsync(CancellationToken cancellationToken)
        {
            return await _entities.Where(s => s.IsActive).AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                await _entities.AddAsync(entity, cancellationToken);
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

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive).CountAsync(cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            entity.SetIsActive(false);
        }
    }