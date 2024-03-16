
using System.Data;
using Mc2.Crud.Persistanse.DbContexts;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mc2.Crud.Persistanse.DbContext;

public class MyAppContext : Microsoft.EntityFrameworkCore.DbContext , IDbContext 
{
    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
    {
  
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppContext).Assembly);
    public IDbConnection Connection => Database.GetDbConnection();
    public DatabaseFacade datbase => Database;
    public DbSet<Customer> Customers { get;  }

}