using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Customer.Query.GetCusomerById
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerByIdQuery , CustomerResponse>
    {
        private readonly IDbConnection _dbConnection;

        public GetCustomerQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<CustomerResponse> Handle (
            GetCustomerByIdQuery request ,
            CancellationToken cancellationToken)
        {
            const string sql = @"SELECT * FROM ""Customers"" WHERE ""iD"" = @CustomerId";
            var Customer = await _dbConnection.QueryFirstOrDefaultAsync<CustomerResponse>(sql, new { request.CustomerId });
            if (Customer == null) throw KeyNotFoundException();
            return Customer;
        }
    }

    internal class CustomerResponse
    {
    }
}
