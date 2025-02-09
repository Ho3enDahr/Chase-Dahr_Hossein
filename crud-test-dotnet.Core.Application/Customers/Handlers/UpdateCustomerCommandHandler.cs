using crud_test_dotnet.Core.Application.Customers.Commands;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Core.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Handlers
{
    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customer;
        private readonly IEventStore _eventStore;
        public UpdateCustomerCommandHandler(ICustomerRepository customer, IEventStore eventStore)
        {
            _customer = customer;
            _eventStore = eventStore;
        }
        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            var bankAccountNumber = new BankAccountNumber(request.BankAccountNumber);
            var customer = Customer.Update(request.Id, request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.BankAccountNumber, request.DateOfBirth);

            var result = await _customer.UpdateAsync(customer);
            foreach (var @event in customer.GetEvents())
            {
                _eventStore.Save(@event);
            }
            return result;
        }
    }
}
