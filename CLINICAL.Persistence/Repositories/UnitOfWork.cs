using CLINICAL.Domain;
using CLINICAL.Interface;
using CLINICAL.Persistence.Context;

namespace CLINICAL.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public readonly ApplicationDbContext _context;
    public IGenericRepository<Analysis> Analysis { get; }
    public IUserRepository User { get;  }
    
    public UnitOfWork( ApplicationDbContext context, IGenericRepository<Analysis> analysis)
    {
        _context = context;
        Analysis = analysis;
        User = new UserRepository(_context);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}