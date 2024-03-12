using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}