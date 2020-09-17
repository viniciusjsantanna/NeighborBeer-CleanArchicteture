using AutoMapper;
using NeighborBeer.Application.DTOs.Customer;
using NeighborBeer.Domain.Entities.Customer;
using System.Net;

namespace NeighborBeer.Application.AutoMapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Person.Name))
                .ForMember(e => e.Cpf, opt => opt.MapFrom(e => e.Cpf.ToString()))
                .ForMember(e => e.Message, opt => opt.Ignore())
                .ForMember(e => e.Messages, opt => opt.Ignore())
                .ForMember(e => e.StatusCode, opt => opt.Ignore());
        }
    }
}
