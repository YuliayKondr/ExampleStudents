using ExampleInfrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExampleInfrastructure.Repositories;

public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    public EfCoreRepository(IDataContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public void Delete(TEntity entity) => _dbSet.Remove(entity);

    public void Insert(TEntity entity) => _dbSet.Add(entity);

    public IQueryable<TEntity> Queryable() => _dbSet;

    public void Update(TEntity entity) => _dbSet.Update(entity);
}