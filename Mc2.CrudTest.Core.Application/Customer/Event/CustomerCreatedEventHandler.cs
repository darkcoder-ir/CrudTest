using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Entities.Events;
using MediatR;

namespace Mc2.CrudTest.Core.Application.Customer.Event
{
    internal class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public CustomerCreatedEventHandler()
        {
            
        }
        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {

            Console.WriteLine("EventRised");
            //throw new NotImplementedException();
        }
    }
}
