using FastExpressionCompiler;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Core.Application.Abstracation.Behavior;
using Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Core.Application.Customer.Event;
using Mc2.CrudTest.Core.Application.Mapper;
using Mc2.CrudTest.Core.Application.Services;
using Mc2.CrudTest.Core.Domain.Models;

namespace Mc2.CrudTest.Core.Application
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Maybe you see anothers services that was not nessecary , inow , i am trying to create a bew pattern except inbound and ourbount ,
        /// I wabt to Use reflection to create every instance from any layyer i want....
        /// at the end i willl remove them ;
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMap>();
            });
            //ServiceProvider? serviceProvider = services.BuildServiceProvider();
            //var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
                services.AddScoped<Response> ();
            services.AddScoped<IValidator<CreateCustomerCommand>, CreateUpdateCustomerValidator>();
            services.AddMediatR(config =>
            {
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
               config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                config.RegisterServicesFromAssemblies(typeof(CustomerCreatedEventHandler).Assembly);
          
            });
            services.AddScoped<ICustomerService, CustomerService>();

            // Mapster
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
            //using (var scope = scopeFactory.CreateScope())
            //{
            //    // Resolve services within the scope
            //    IDbContext? myScopedService = scope.ServiceProvider.GetRequiredService<IDbContext>();
            //    // Now you can use myScopedService...
            //}

            return services;
        }

    }
}
