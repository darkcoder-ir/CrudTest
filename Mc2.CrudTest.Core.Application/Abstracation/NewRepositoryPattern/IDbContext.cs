using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

public interface IDbContext
{
   
    DatabaseFacade datbase { get; }
    DbSet<Domain.Entities.Customer> Customers { get; }
  
}