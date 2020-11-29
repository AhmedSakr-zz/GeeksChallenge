using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.CloudLibrary.Validations
{
    public class InfrastructureResourceOptionForPostValidator : AbstractValidator<InfrastructureResourceOptionUpsertDto>
    {
        public InfrastructureResourceOptionForPostValidator()
        {
            RuleFor(t => t.Value).NotEmpty();
            RuleFor(t => t.ServiceOptionId).NotEmpty().GreaterThan(0);
            RuleFor(t => t.ServiceOptionName).NotEmpty();
        }
    }
}
