using crud_test_dotnet.Core.Application.Customers.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Customers.Queries
{
    public class GetCustomersQuery:IRequest<List<GetCustomerDTO>>
    {
    }
}
