using FluentValidation;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.CloudLibrary.Validations
{
    public class InfrastructureResourceForPostValidator:AbstractValidator<InfrastructureResourceUpsertDto>
    {
        public InfrastructureResourceForPostValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.InfrastructureName).NotEmpty();
            RuleFor(t => t.ServiceId).GreaterThan(0);
            RuleFor(t => t.ServiceName).NotEmpty();
        }
    }
}
