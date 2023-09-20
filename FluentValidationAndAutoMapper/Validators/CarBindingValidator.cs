using FluentValidation;
using FluentValidationAndAutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationAndAutoMapper.Validators
{
    internal class CarBindingValidator : AbstractValidator<CarBindingModel>
    {
        public CarBindingValidator() 
        {
            RuleFor(x => x.Make).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Model).MaximumLength(50).NotEmpty();
            RuleFor(x => x.CarType).IsInEnum();
            RuleFor(x => x.SeatsNumber).InclusiveBetween(1, 7);
        }
    }
}
