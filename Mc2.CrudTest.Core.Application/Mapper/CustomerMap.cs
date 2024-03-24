using AutoMapper;
using Mc2.CrudTest.Core.Application.Customer;

namespace Mc2.CrudTest.Core.Application.Mapper;

public class CustomerMap : Profile
{
    public CustomerMap()
    {
        CreateMap<CustomerViewModel, Domain.Entities.Customer>();
    }
}