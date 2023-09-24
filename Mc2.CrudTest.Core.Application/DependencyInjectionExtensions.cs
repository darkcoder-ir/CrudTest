using FastExpressionCompiler;
using Mapster;
using Mc2.CrudTest.Core.Application.Abstracation.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, bool addValidation = false, bool addRequestLogging = false, bool useReadThroughCachingForQueries = false)
        {
            services.Scan(scan =>
                scan
                .FromCallingAssembly()

                .AddClasses(classes => classes.AssignableTo(typeof(IDbEntityToDomainEntityMapper<,>))).AsImplementedInterfaces().WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IDbEntityToValueObjectMapper<,>))).AsImplementedInterfaces().WithSingletonLifetime()

                .AddClasses(classes => classes.AssignableTo(typeof(IViewModelToDbEntityMapper<,>))).AsImplementedInterfaces().WithSingletonLifetime()

            );

            if (addValidation)
            {
              //  services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
              //  best peractice is create pipeline for any request and validate and event storing there
            }

            if (addRequestLogging)
            {
               // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            }

            if (useReadThroughCachingForQueries)
            {
                //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestCachingBehavior<,>));
            }

           

            // Mapster
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();

            return services;
        }

    }
}
