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
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customer;
        private readonly IEventStore _eventStore;
        public DeleteCustomerCommandHandler(ICustomerRepository customer, IEventStore eventStore)
        {
            _customer = customer;
            _eventStore = eventStore;
        }
        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
           
            var result = await _customer.DeleteAsync(request.Id);
            var customer = Customer.Delete(result.Id, result.FirstName, result.LastName, result.PhoneNumber.Value, result.Email.Value, result.BankAccountNumber.Value, result.DateOfBirth);
            foreach (var @event in customer.GetEvents())
            {
                _eventStore.Save(@event);
            }
            return result;
        }
    }
}
