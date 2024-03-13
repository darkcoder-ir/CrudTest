using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.Crud.Persistanse;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T :class, IAggregateRoot
{
    public EfRepository(DbContext dbContext) : base(dbContext)
    {


    }

}