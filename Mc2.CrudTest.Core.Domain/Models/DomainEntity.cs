using Mc2.CrudTest.Core.Domain.Abstracation;
using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Models
{
    public abstract class DomainEntity : IDomainEntity
    {
        public int Id { get; set; }
        private static IDomainEventDispatcher dispatcher = new NullDomainEventDispatcher();
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();
        public void AddDomainEvent(IDomainEvent eventItem) => domainEvents.Add(eventItem);
        public void ClearDomainEvents() => domainEvents?.Clear();
        public async Task DispatchDomainEventsAsync()
        {
            foreach (var domainEvent in domainEvents)
            {
                await dispatcher.PublishAsync(domainEvent);
            }
            ClearDomainEvents();
        }
        public bool Equals(DomainEntity other) => other != null && Id.Equals(other.Id);
        public virtual void ValidateAggregate()
        {
        }

        public override bool Equals(object? obj) => obj is DomainEntity entity && entity != null ? Equals(entity) : base.Equals(obj);
        public override int GetHashCode() => Id;
        public void RemoveDomainEvent(IDomainEvent eventItem) => domainEvents?.Remove(eventItem);
        internal static void WireUpDispatcher(IDomainEventDispatcher dispatcher) => DomainEntity.dispatcher = dispatcher;

    }
}
