using MediatR;
namespace Mc2.CrudTest.Core.Domain.Abstracation.Events;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent
{
}