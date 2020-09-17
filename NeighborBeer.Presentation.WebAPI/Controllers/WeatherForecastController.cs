using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeighborBeer.Application.Commands.RegisterCustomer;
using NeighborBeer.Application.DTOs;
using NeighborBeer.Application.DTOs.Customer;
using NeighborBeer.Application.Queries;

namespace NeighborBeer.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Response> Get()
        {
            return this._mediator.Send(new RegisterCustomerCommand("Vinicius","Santana"));
        }
    }
}
