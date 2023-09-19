using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator mediator;
        public DomainEventDispatcher(IMediator mediator) => this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        public async Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent =>  await mediator.Publish(domainEvent);
    }
}
