using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public class AddOrUpdateCustomerCommand : IRequest<CustomerViewModel>
    {
        public CustomerViewModel Customer { get; init; } = default!;
        public class AddOrUpdateCustomerCommandHandler : IRequestHandler<AddOrUpdateCustomerCommand, CustomerViewModel>
        {
            private readonly IApplicationWriteDbContext context;

            public async Task<CustomerViewModel> Handle(AddOrUpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                // PRESENTATION/APPLICATION LAYER
                var customerViewModel = request.Customer;
                CustomerEntity entity = new();// it must maping from custo
                var customerAdded = false;
                await context.Customers.AddAsync(customerEntity, cancellationToken);
                return customerViewModel;
            }
        }
    }
}