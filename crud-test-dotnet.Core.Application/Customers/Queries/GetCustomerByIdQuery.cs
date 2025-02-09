using AutoMapper;
using crud_test_dotnet.Core.Application.Common.Mapping;
using crud_test_dotnet.Core.Application.Customers.DTOs;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using crud_test_dotnet.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<GetCustomerDTO>
    {
    }
  
}
