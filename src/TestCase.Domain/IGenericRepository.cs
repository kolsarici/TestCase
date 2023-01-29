using System.Linq.Expressions;
using TestCase.Domain.Entities;

namespace TestCase.Domain;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id, bool isActive = true);
    Task<List<TEntity>> AllAsync(bool isActive = true);
    Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
    Task SaveAsync(TEntity entity);
    TEntity Update(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
    void Delete(TEntity entity);
   

}