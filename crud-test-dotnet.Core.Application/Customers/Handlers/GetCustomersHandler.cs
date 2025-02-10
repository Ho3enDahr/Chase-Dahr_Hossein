using AutoMapper;
using crud_test_dotnet.Core.Application.Customers.DTOs;
using crud_test_dotnet.Core.Application.Customers.Queries;
using crud_test_dotnet.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Handlers
{
    internal class GetCustomersHandler : IRequestHandler<GetCustomersQuery, List<GetCustomerDTO>>
    {
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapper;
        public GetCustomersHandler(ICustomerRepository customer, IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        public async Task<List<GetCustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
           var customers =await _customer.GetAllAsync();
            var result = _mapper.Map<List<GetCustomerDTO>>(customers);
            return result;
        }
    }
}
