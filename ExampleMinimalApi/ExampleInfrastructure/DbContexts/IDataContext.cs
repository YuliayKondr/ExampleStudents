using Microsoft.EntityFrameworkCore;

namespace ExampleInfrastructure.DbContexts
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}