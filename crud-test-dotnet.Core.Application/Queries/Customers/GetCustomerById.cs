using AutoMapper;
using crud_test_dotnet.Core.Application.Common.Mapping;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Queries.Customers
{
    public record GetCustomerById : IRequest<GetCustomerByIdDTO>
    {
        public Guid Id { get; set; }
       
    }
    internal class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, GetCustomerByIdDTO>
    {
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapperr;
        public GetCustomerByIdHandler(ICustomerRepository customer, IMapper mapper)
        {
            _customer = customer;
            _mapperr = mapper;
        }
        public async Task<GetCustomerByIdDTO> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            var customer  =await _customer.GetByIdAsync(request.Id);
            if (customer == null)
                throw new Exception( "not found");
            var result =_mapperr.Map<GetCustomerByIdDTO>(customer);
            return  result;
        }
    }
}
