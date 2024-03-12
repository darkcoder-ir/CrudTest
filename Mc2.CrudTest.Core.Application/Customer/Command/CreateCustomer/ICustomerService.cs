using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public interface ICustomerService
    {
        Task<string?> GetCommandType();
    }
    public class CustomerService : ICustomerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string?> GetCommandType() //I would not using Jwt token because that not this tasks consince
        {                                       //simply geting CustomerUd from Headers, i know for secuire it should comes from token claims...
            if (_httpContextAccessor is null
                || _httpContextAccessor.HttpContext is null
                || _httpContextAccessor.HttpContext.Request is null)
                return null;
            try
            {
                StringValues Customer = _httpContextAccessor.HttpContext.Request.Headers["RequestType"];
                string? res = Customer.FirstOrDefault();
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Header error");
            }

            return null;
        }
    }
}