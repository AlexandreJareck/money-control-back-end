using Microsoft.EntityFrameworkCore;
using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Models;
using MoneyControl.Data.Context;
using System.Linq.Expressions;

namespace MoneyControl.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MoneyControlDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(MoneyControlDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChange();
    }

    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task Remove(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChange();
    }

    public async Task Update(TEntity model)
    {
        DbSet.Update(model);
        await SaveChange();
    }

    public async Task<int> SaveChange()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}
