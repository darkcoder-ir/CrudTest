using Mc2.CrudTest.Core.Domain.Events;

namespace Mc2.CrudTest.Core.Domain.Entities.Events
{
    public  class CustomerUpdatedEvent :DomainEvent
    {
        public Domain.Entities.Customer Customer { get; }

        public CustomerUpdatedEvent(Domain.Entities.Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}
