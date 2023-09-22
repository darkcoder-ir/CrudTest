using Mc2.CrudTest.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Resources
{
    public  class CustomerUpdatedEvent :DomainEvent
    {
        public Customer Customer { get; }

        public CustomerUpdatedEvent(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}
