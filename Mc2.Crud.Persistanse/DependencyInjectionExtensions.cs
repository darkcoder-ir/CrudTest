using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mc2.Crud.Persistanse.DbContext;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Microsoft.EntityFrameworkCore.Internal;

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
        services.AddScoped<IDbContext>(provider =>
        {
            // Resolve the DbContext from the service provider
            var dbContext = provider.GetRequiredService<MyAppContext>();
            return dbContext;
        });
            services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository> ();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            return services;
      }
  }
}