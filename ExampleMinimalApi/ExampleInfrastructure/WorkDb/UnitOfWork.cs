using ExampleInfrastructure.DbContexts;

namespace ExampleInfrastructure.WorkDb;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataContext _dataContext;

    public UnitOfWork(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dataContext.SaveChangesAsync(cancellationToken);
    }
}