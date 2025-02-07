using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Core.Domain.ValueObjects;
using MediatR;

namespace crud_test_dotnet.Core.Application.Commands.CustomerManagement.Create
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customer;
        public CreateCustomerCommandHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            var bankAccountNumber = new BankAccountNumber(request.BankAccountNumber);
            var customer = new Customer(
                new Guid(),
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                phoneNumber,
                email,
                bankAccountNumber
                );
            var result = _customer.AddAsync(customer);
            return result;
        }
    }
}
