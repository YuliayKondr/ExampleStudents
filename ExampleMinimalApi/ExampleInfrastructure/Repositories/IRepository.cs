namespace ExampleInfrastructure.Repositories;

public interface IRepository <TEntity> where TEntity : class
{
    void Delete(TEntity entity);

    void Insert(TEntity entity);

    IQueryable<TEntity> Queryable();

    void Update(TEntity entity);
}