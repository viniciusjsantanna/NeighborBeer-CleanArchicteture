using MediatR;
using NeighborBeer.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Application.Queries
{
    public class GetAllCustomerQuery : IRequest<CustomerDTO>
    {
    }
}
