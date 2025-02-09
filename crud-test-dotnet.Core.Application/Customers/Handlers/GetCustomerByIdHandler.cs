using AutoMapper;
using crud_test_dotnet.Core.Application.Customers.DTOs;
using crud_test_dotnet.Core.Application.Customers.Queries;
using crud_test_dotnet.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Handlers
{
    internal class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerDTO>
    {
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapperr;
        public GetCustomerByIdHandler(ICustomerRepository customer, IMapper mapper)
        {
            _customer = customer;
            _mapperr = mapper;
        }
        public async Task<GetCustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customer.GetByIdAsync(request.Id);
            if (customer == null)
                throw new Exception("not found");
            var result = _mapperr.Map<GetCustomerDTO>(customer);
            return result;
        }
    }
}
