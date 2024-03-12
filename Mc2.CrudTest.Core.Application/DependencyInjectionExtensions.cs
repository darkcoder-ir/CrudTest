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
using AutoMapper;
using Mc2.CrudTest.Core.Application.Mapper;

namespace Mc2.CrudTest.Core.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, bool addValidation = false, bool addRequestLogging = false, bool useReadThroughCachingForQueries = false)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMap>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.Scan(scan =>
                scan
                .FromCallingAssembly()
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
