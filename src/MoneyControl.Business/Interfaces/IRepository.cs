using MoneyControl.Business.Models;
using System.Linq.Expressions;

namespace MoneyControl.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Remove(Guid id);

    Task Add(TEntity entity);

    Task Update(TEntity model);

    Task<List<TEntity>> GetAll();

    Task<TEntity> GetById(Guid Id);

    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
}
