using Mc2.CrudTest.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Entities;

namespace Mc2.CrudTest.Core.Domain.Resources
{
    public class CustomerCreatedEvent :DomainEvent
    {
        public Customer Customer { get;  }

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}
