using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Mc2.CrudTest.Core.Application.Abstracation.Mapping;

namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public class AddOrUpdateCustomerCommand : IRequest<CustomerViewModel>
    {
        public CustomerViewModel Customer { get; init; } = default!;
        public class AddOrUpdateCustomerCommandHandler : IRequestHandler<AddOrUpdateCustomerCommand, CustomerViewModel>
        {
            private readonly IApplicationWriteDbContext context;
          //  private readonly IViewModelToDbEntityMapper<CustomerViewModel, CustomerEntity> customerMapper;
          //  simple way using static class for mapping and creating domainModel with ObjectValues ==> forget mapster pattern imp
             

            public AddOrUpdateCustomerCommandHandler(IApplicationWriteDbContext context, IViewModelToDbEntityMapper<CustomerViewModel, CustomerEntity> customerMapper)
            {
                this.context = context;
               // this.customerMapper = customerMapper;   
            }

            public async Task<CustomerViewModel> Handle(AddOrUpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                //to impliment Event storing i could using rabbitMQ to store events there or i simply create event table and make record for any event there // i am sorry i didnt have time to imp thats
                // PRESENTATION/APPLICATION LAYER
                var customerViewModel = request.Customer;

                // PERSISTENCE LAYER
                var customerAdded = false;
                using (var transaction = await context.Database.BeginTransactionAsync(cancellationToken))
                {
                    var sqlTransaction = transaction.GetDbTransaction();
                    var customerEntity = await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.FirstName == request.Customer.FirstName && c.LastName== request.Customer.LastName && c.DateOfBirth == request.Customer.DateOfBirth, cancellationToken: cancellationToken);
                    if (customerEntity != null)
                    {
                        // Update.
                        customerEntity= ViewModelToDbEntityMapper.customerMap(customerViewModel);
                         context.Customers.Update(customerEntity);
                        context.Entry(customerEntity).State = customerAdded ? EntityState.Modified : EntityState.Modified;
                    }
                    else
                    {
                        // Add.
                        customerEntity = ViewModelToDbEntityMapper.customerMap(customerViewModel);
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