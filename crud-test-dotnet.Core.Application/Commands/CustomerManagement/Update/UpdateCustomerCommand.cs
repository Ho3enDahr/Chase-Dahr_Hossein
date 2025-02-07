using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Core.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Commands.CustomerManagement.Update
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customer;
        public UpdateCustomerCommandHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
            var result = _customer.UpdateAsync(customer);
            return result;
        }
    }
}
