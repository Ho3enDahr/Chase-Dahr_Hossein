using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crud_test_dotnet.Core.Application.Customers.Commands;
using crud_test_dotnet.Core.Application.Customers.Queries;

namespace crud_test_dotnet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromBody] GetCustomerByIdQuery command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
    }
}
