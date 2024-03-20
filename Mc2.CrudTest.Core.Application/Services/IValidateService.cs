using System.ComponentModel;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Core.Application.Services;

public interface IValidateService
{
    public Task< bool> CheckCustomerExsistByFullName(string firstname , string lastname , string datteBitrh);
    public Task<bool> CheckCustomerExsistByEmail(string email);

}

public class ValidataService : IValidateService
{
    private readonly IDbContext _dbContext;

    public ValidataService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<bool> CheckCustomerExsistByFullName(string firstname, string lastname, string datteBitrh)
    {
        var res = await _dbContext.Customers.Where(w =>
                w.FirstName == firstname && w.LastName == lastname && w.DateOfBirth == datteBitrh)
            .FirstOrDefaultAsync();
        if (res == null)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> CheckCustomerExsistByEmail(string email)
    {
        var res = await _dbContext.Customers.Where(w => w.Email == email)
            .FirstOrDefaultAsync();
        if (res == null) 
        {
            return false;
        }
        return true;
        
    }
}