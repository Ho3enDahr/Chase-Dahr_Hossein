using AutoMapper;
using crud_test_dotnet.Core.Application.Queries.Customers;
using crud_test_dotnet.Core.Domain.Entities.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_test_dotnet.Core.Application.Common.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerByIdDTO>()
                .ForMember(des => des.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
                .ForMember(des => des.BankAccountNumber, opt => opt.MapFrom(src => src.BankAccountNumber.Value));
        }
    }
}
