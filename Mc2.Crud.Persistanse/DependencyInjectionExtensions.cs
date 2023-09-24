using Mc2.Crud.Persistanse.DbContexts;
using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistanse
{
    public static  class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationWriteDbContext>(options =>
                options
                .UseSqlServer("DataBase=. ......................")
                .EnableSensitiveDataLogging(true)
                );

            services.AddScoped<IApplicationWriteDbContext>(provider => provider.GetService<ApplicationWriteDbContext>() ?? throw new Exception("Could not get DB context."));
            services.AddScoped<IApplicationReadDbFacade, ApplicationReadDbFacade>();

            return services;
        }
    }
}
