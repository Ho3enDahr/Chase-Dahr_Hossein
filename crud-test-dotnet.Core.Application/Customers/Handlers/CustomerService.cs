using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Events;
using crud_test_dotnet.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Handlers
{
    public class CustomerService
    {
        private readonly IEventStore _eventStore;
        public CustomerService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public Customer GetById(Guid id)
        {
            var events = _eventStore.GetEvents(id);
            var customer = new Customer();
            foreach (var @event in events)
            {
                if(@event is CustomerCreatedEvent e)
                {
                    customer = Customer.Create(e.Firstname, e.Lastname, e.Phonenumer, e.Email, e.BankAccountNumber, e.DateOfBirth);
                }
            }
            return customer;
        }
    }
}
