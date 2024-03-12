using MediatR;
using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Models;


namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response>
    { public CustomerViewModel Customer { get; init; } = default!;
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response>
        {
            public CreateCustomerCommandHandler(IReadRepository<Domain.Entities.Customer> CustomerRepository)
            {
                customerRepository = CustomerRepository;
            }
            private readonly IReadRepository<Domain.Entities.Customer> customerRepository;
            private readonly ICustomerService _iCustomerService;
            public async Task<Response> Handle(CreateCustomerCommand request,
                CancellationToken cancellationToken)
            {
                var User = _iCustomerService.GetCustomerId();
                var customerViewModel = request.Customer;
                var customerAdded = false;
                using (var transaction = await context.Database.BeginTransactionAsync(cancellationToken))
                {
                    var sqlTransaction = transaction.GetDbTransaction(); // For Handling Scenario for there was sql transAction already exsist for this entity
                                                                        // Like waiting wor commit ang update them or insert after than or geting last result in Case of every bussines Requirment
                    var customerEntity = await context.Customers.AsNoTracking().FirstOrDefaultAsync(
                        c => c.FirstName == request.Customer.FirstName && c.LastName == request.Customer.LastName &&
                             c.DateOfBirth == request.Customer.DateOfBirth, cancellationToken: cancellationToken);
                    if (customerEntity != null)
                    {
                        // Update.

                        context.Customers.Update(customerEntity);
                        context.Entry(customerEntity).State =
                            customerAdded ? EntityState.Modified : EntityState.Modified;
                    }
                    else
                    {
                        // Add.

                        customerAdded = true;
                        await context.Customers.AddAsync(customerEntity, cancellationToken);
                        context.Entry(customerEntity).State = customerAdded ? EntityState.Added : EntityState.Modified;
                    }


                    await context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                }

                return customerViewModel;
            }
        }
    }
}