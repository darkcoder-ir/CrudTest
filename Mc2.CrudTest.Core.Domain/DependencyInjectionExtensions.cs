using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using Mc2.CrudTest.Core.Domain.Events;
using Mc2.CrudTest.Core.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
            return services;
        }
        public static IServiceProvider WireUpDomainEventHandlers(this IServiceProvider serviceProvider)
        {
            DomainEntity.WireUpDispatcher(serviceProvider.GetRequiredService<IDomainEventDispatcher>());
            return serviceProvider;
        }

    }
}
