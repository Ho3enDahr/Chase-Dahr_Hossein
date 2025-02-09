using crud_test_dotnet.Core.Application.Customers.Commands;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Handlers
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customer;
        private readonly IEventStore _eventStore;
        public CreateCustomerCommandHandler(ICustomerRepository customer, IEventStore eventStore)
        {
            _customer = customer;
            _eventStore = eventStore;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.BankAccountNumber, request.DateOfBirth);
            var result = await _customer.AddAsync(customer);
            foreach (var @event in customer.GetEvents())
            {
                _eventStore.Save(@event);
            }
            return result;
        }
    }
}
