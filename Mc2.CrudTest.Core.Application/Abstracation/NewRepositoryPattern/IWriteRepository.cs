using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
public interface IWriteRepository<T>  where T : class, IAggregateRoot  // IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}