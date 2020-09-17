using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NeighborBeer.Application.DTOs.Customer;
using NeighborBeer.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NeighborBeer.Application.Queries
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, CustomerDTO>
    {
        public IMapper _mapper { get; set; }
        public IEFContext _context { get; set; }
        public GetAllCustomerHandler(IEFContext Context, IMapper Mapper)
        {
            this._context = Context;
            this._mapper = Mapper;
        }
        public async Task<CustomerDTO> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var id = 1;
            var result = this._mapper.Map<CustomerDTO>(this._context.Customers.FindAsync(id).Result);
            return await Task.FromResult(result);
        }
    }
}
