using FluentValidation;
using NeighborBeer.Application.Commands.RegisterCustomer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeighborBeer.Application.Validations.Customer
{
    public class RegisterCustomerValidation : AbstractValidator<RegisterCustomerCommand>
    {
        public RegisterCustomerValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Atributo Nome está vazio!");

            RuleFor(e => e.LastName)
                .NotEmpty()
                .WithMessage("Atributo Sobrenome está vazio!");
        }
    }
}
