
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Customer.Command.DeleteCustomer
{
    //public class DeleteCustomerCommand : IRequest<bool>
    //{
    //    public CustomerViewModel Customer { get; set; } = default;
    //    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    //    {
    //        private readonly IApplicationWriteDbContext context;

    //        public DeleteCustomerCommandHandler(IApplicationWriteDbContext context)
    //        {
    //            this.context = context;
    //        }

    //        public Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    //        {
    //            var CustomerViewModel = request.Customer;
    //            //context.Customers.Remove(new CustomerEntity { FirstName = CustomerViewModel.FirstName, LastName = CustomerViewModel.LastName, DateOfBirth = CustomerViewModel.DateOfBirth });
    //            //context.SaveChangesAsync();
    //            return (Task<bool>)Task.CompletedTask;
    //            // ofcourse it was better if i create IsRemoved property and do changing the value to zero 
                
    //        }
    //    }

    //}
}
