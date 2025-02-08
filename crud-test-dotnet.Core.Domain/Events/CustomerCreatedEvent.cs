using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Domain.Events
{
    public class CustomerCreatedEvent:DomainEvent
    {
        public CustomerCreatedEvent(Guid customerId, string firstname, string lastname, string phonenumer, string email, string bankAccountNumber)
        {
            CustomerId = customerId;
            Firstname = firstname;
            Lastname = lastname;
            Phonenumer = phonenumer;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public Guid CustomerId { get; set; }
        public string Firstname { get; }
        public string Lastname { get;  }
        public string Phonenumer { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }

    }
}
