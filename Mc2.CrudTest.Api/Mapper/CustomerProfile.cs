using AutoMapper;
using Mc2.CrudTest.Api.Models;

namespace Mc2.CrudTest.Api.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerRequest>();
            CreateMap<CustomerRequest, Customer>();

            CreateMap<Customer, CustomerUpdateRequest>();
            CreateMap<CustomerUpdateRequest, Customer>();
        }
    }
}
