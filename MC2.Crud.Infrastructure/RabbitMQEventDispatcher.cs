using Mc2.CrudTest.Core.Domain.Abstracation.Events;

namespace MC2.Crud.Infrastructure;

public class RabbitMQEventDispatcher : IDomainEventDispatcher
{
    public Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        throw new NotImplementedException();
    }
}