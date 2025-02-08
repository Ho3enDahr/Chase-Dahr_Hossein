using crud_test_dotnet.Core.Application.Commands.CustomerManagement.Create;
using crud_test_dotnet.Core.Application.Commands.CustomerManagement.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletCustomer([FromBody] DeleteCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
        }
    }
}
