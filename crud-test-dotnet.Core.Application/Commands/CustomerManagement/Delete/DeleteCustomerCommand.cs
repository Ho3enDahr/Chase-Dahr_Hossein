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
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
       
    }
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customer;
        public DeleteCustomerCommandHandler(ICustomerRepository customer)
        {
            _customer = customer;
        }
        public Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
           
            var result = _customer.DeleteAsync(request.Id);
            return result;
        }
    }
}
