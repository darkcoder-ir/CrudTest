using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Events
{
    public sealed class NullDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent => Task.CompletedTask;
    }
}
