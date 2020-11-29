using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.CloudLibrary.Validations
{
    public class InfrastructureUpsertValidator:AbstractValidator<InfrastructureUpsertDto>
    {
        public InfrastructureUpsertValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.CloudProviderId).NotEmpty().GreaterThan(0);
            RuleFor(t => t.CloudProviderName).NotEmpty();
        }
    }
}
