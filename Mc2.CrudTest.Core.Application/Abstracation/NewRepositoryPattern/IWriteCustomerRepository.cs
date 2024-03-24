using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
public interface IWriteCustomerRepository   // IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    Task<int> SaveChangesAsync(Domain.Entities.Customer entity);
    Task<int> AddAsync(Domain.Entities.Customer entity);
    Task<int> UpdateAsync(Domain.Entities.Customer entity);
    Task DeleteAsync(Domain.Entities.Customer entity);





}