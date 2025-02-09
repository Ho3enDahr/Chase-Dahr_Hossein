using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using crud_test_dotnet.Core.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Commands
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

}
