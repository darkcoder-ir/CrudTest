using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Customer.Query.GetCusomerById
{
    public class GetCustomerQuery :  IRequest<CustomerViewModel?>
    {
        public CustomerViewModel _Customer { get; set; } = default!;
        public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerQuery, CustomerViewModel?>
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string DateOfBirth { get; private set; }
            private readonly IApplicationReadDbFacade facade;

            public GetCustomerListQueryHandler(IApplicationReadDbFacade facade) => this.facade = facade ?? throw new ArgumentNullException(nameof(facade));

            public async Task<CustomerViewModel?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                FirstName = request._Customer.FirstName;
                LastName = request._Customer.LastName;
                DateOfBirth=request._Customer.DateOfBirth;

                // i liked create multiple entities for customer and BankAccount Even mobile then multiple domain then create aggregate for them then i using custome tsql query joining for better performance 
                var customer = await facade.QueryFirstOrDefaultAsync<CustomerViewModel?>(@"SELECT
                      *
                  FROM [dbo].[Customers] c WITH(NOLOCK)
				  where c.FirstName=@FirstName and c.LastName=@LastName and c.DateOfBirth = @DateOfBirth ", request, cancellationToken: cancellationToken);
                return customer;
            }
        }
    }
}
