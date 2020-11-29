using System;
using FluentValidation;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.Application.Validations
{
    public class ServiceOptionsUpsertDtoValidator : AbstractValidator<ServiceOptionsUpsertDto>
    {
        public ServiceOptionsUpsertDtoValidator()
        {
            RuleFor(o => o.Name).MaximumLength((8000));
            RuleFor(o => o.ServiceId).GreaterThan(0);
        }
    }
}
