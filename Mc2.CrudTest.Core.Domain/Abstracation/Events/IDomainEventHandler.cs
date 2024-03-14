using MediatR;
namespace Mc2.CrudTest.Core.Domain.Abstracation.Events;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
{
    public Task PublishAsync<TEvent>(TEvent domainEvent);
}