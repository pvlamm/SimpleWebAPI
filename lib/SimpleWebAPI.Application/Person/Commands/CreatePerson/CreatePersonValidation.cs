namespace SimpleWebAPI.Application.Person.Commands
{
    using FluentValidation;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Application.Common.Messages;

    public class CreatePersonValidation : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidation(IPersonService personService, IPersonMemoryCache personMemoryCache)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_CANNOT_BE_EMPTY)
                .MaximumLength(75)
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_TOO_LONG)
                .Must(name =>
                    !personService.PersonExists(name))
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_EXISTS);

            RuleFor(x => x.Address)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.ERROR_ADDRESS_CANNOT_BE_EMPTY)
                .MaximumLength(150)
                    .WithMessage(ValidationErrorMessages.ERROR_ADDRESS_TOO_LONG);
        }
    }
}
