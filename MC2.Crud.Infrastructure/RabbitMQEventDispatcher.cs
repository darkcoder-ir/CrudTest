using Mc2.CrudTest.Core.Domain.Abstracation.Events;

namespace MC2.Crud.Infrastructure;

public  class RabbitMQEventDispatcher :  IDomainEventDispatcher,IRabbitMqventDispatcher
{
    async Task IDomainEventDispatcher.PublishAsync<TEvent>(TEvent domainEvent)
    {
        throw new NotImplementedException();
    }

    async Task IRabbitMqventDispatcher.PublishAsync<TEvent>(TEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}
public interface IRabbitMqventDispatcher  : IDomainEventDispatcher
{

    Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
}