using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighborBeer.Application.Interfaces
{
    public interface IExceptionHandler<TResponse>
        where TResponse : class
    {
        Task<TResponse> Handle(Exception exception); 
    }
}
