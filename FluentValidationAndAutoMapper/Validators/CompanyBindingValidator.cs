using FluentValidation;
using FluentValidationAndAutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationAndAutoMapper.Validators
{
    internal class CompanyBindingValidator : AbstractValidator<CompanyBindingModel>
    {
        public CompanyBindingValidator() 
        {
            RuleFor(x =>  x.Name).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(200);
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Phone).Matches("^[0-9]{12}$").WithMessage("\'Phone\' must consist of 12 symbols from 0 to 9");
        }
    }
}
