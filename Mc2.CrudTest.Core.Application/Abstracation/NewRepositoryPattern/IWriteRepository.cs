using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
public interface IWriteRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    
}