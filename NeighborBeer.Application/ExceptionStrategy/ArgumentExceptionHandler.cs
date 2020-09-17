using NeighborBeer.Application.DTOs;
using NeighborBeer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighborBeer.Application.ExceptionStrategy
{
    public class ArgumentExceptionHandler : IExceptionHandler<Response>
    {
        public Task<Response> Handle(Exception exception)
        {
            var response = new Response
            {
                Message = "ArgumentException"

            };

            return Task.FromResult(response);
        }
    }
}
