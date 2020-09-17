using MediatR;
using NeighborBeer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeighborBeer.Application.Commands.RegisterCustomer
{
    public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand, Response>
    {
        public Task<Response> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new ArgumentException();
            //throw new NotImplementedException();
            //var response = new Response()
            //{

            //    Message = "Cliente registrado com sucesso!",
            //    StatusCode = System.Net.HttpStatusCode.OK
            //};

            //return Task.FromResult(response);
        }
    }
}
