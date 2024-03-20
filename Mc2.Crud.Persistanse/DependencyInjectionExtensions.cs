using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mc2.Crud.Persistanse.DbContext;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

namespace Mc2.CrudTest.Persistanse
{
  public static class DependencyInjectionExtensions
  {
    const string coonectionString =
            "Server =.; DataBase = Local; UID = app; PWD = app; Trusted_Connection = True; TrustServerCertificate = True";

    public static IServiceCollection AddPersistenceLayer (this IServiceCollection services)
      {
        services.AddDbContext<MyAppContext> (options =>
                                                     options
                                                     .UseSqlServer (coonectionString)
                                                     .EnableSensitiveDataLogging (true)
                );
        services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository> ();
                //(provider => provider.GetService<WriteCustomerRepository>() ?? throw new Exception("Could not get DB context."));
        services.AddScoped<IDbContext, MyAppContext> ();

        return services;
      }
  }
}