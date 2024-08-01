using CLINICAL.Domain;

namespace CLINICAL.Interface;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Analysis> Analysis { get; }
    IUserRepository User { get; }
}