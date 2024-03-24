using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using Mc2.CrudTest.Core.Domain.Events;
using Mc2.CrudTest.Core.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MC2.Crud.Infrastructure
{
    public static class DependencyInjection
    {

            public static IServiceCollection AddInfraLayer(this IServiceCollection services)
            {
            // services.AddSingleton<IRabbitMqventDispatcher, RabbitMQEventDispatcher();
                return services;
            }
            public static IServiceProvider WireUpDomainEventHandlers(this IServiceProvider serviceProvider)
            {
                DomainEntity.WireUpDispatcher(serviceProvider.GetRequiredService<IRabbitMqventDispatcher>());
                return serviceProvider;
            }

        }
    
}
