using System.Linq.Expressions;
using TestCase.Domain.Entities;

namespace TestCase.Domain;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<TEntity>> AllAsync(CancellationToken cancellationToken);
    Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken);
    TEntity Update(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    void Delete(TEntity entity);
   

}