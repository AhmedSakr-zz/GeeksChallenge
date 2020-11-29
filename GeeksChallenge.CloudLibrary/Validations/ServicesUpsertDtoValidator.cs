using System;
using FluentValidation;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.Application.Validations
{
    public class ServicesUpsertDtoValidator : AbstractValidator<ServicesUpsertDto>
    {
        public ServicesUpsertDtoValidator()
        {
            RuleFor(o => o.Name).MaximumLength((8000));
        }
    }
}
