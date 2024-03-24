using System.ComponentModel;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Application.Customer;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Core.Application.Services;

public interface IValidateService
{
    bool CheckCustomerExsistByFullName(string firstname , string lastname , string datteBitrh);
   bool CheckCustomerExsistByEmail(string email);

}

public class ValidataService : IValidateService
{
    private readonly IReadRepository<Domain.Entities.Customer> repository;

    public ValidataService(IReadRepository<Domain.Entities.Customer> readRepository)
    {
        repository = readRepository;
    }


    public  bool CheckCustomerExsistByFullName(string firstname, string lastname, string datteBitrh )
    {
        var param = new { FirstName = firstname, LastName = lastname, DateOfBirth = datteBitrh };
        var customer =  repository.QueryFirstOrDefaultAsync<CustomerViewModel>(@"SELECT
                      *
                  FROM [dbo].[Customers] c WITH(NOLOCK)
				  where c.FirstName=@FirstName and c.LastName=@LastName and c.DateOfBirth = @DateOfBirth ", param );
      
        if (customer == null)
        {
            return false;
        }
        return true;
        
    }

    public bool CheckCustomerExsistByEmail(string cuemail)
    {
        var param =new {Email =cuemail};
        var customer =  repository.QueryFirstOrDefaultAsync<CustomerViewModel>(@"SELECT
                      *
                  FROM [dbo].[Customers] c WITH(NOLOCK)
				  where c.Email=@Email ", param);
        if (customer == null) 
        {
            return false;
        }
        return true;
        
    }
}