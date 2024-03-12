using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Models;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}