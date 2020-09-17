using MediatR;
using NeighborBeer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Application.Commands.RegisterCustomer
{
    public class RegisterCustomerCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public RegisterCustomerCommand(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}
