using Mc2.CrudTest.Core.Application.Customer;
using Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Core.Application.Customer.Command.DeleteCustomer;
using Mc2.CrudTest.Core.Application.Customer.Query.GetCusomerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        [HttpPost("[action]")]
        public async Task<ActionResult<CustomerViewModel>> AddOrUpdateCustomer([FromBody] CustomerViewModel customer)
        {
            return Ok(await mediator.Send(new CreateCustomerCommand { Customer = customer }));
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<CustomerViewModel>> GetCustomer([FromBody] CustomerViewModel customer) => Ok(await mediator.Send(new GetCustomerQuery() { _Customer=customer  }));

        [HttpGet("[action]")]
        public async Task<ActionResult<CustomerViewModel>> DeleteCustomer([FromBody] CustomerViewModel customer) => Ok(await mediator.Send(new DeleteCustomerCommand() { Customer= customer }));

    }
}
