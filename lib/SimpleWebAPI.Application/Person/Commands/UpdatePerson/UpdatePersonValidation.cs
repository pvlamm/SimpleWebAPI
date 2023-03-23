namespace SimpleWebAPI.Application.Person.Commands
{
    using FluentValidation;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Application.Common.Messages;

    public class UpdatePersonValidation : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonValidation(IPersonService personService)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_CANNOT_BE_EMPTY)
                .MaximumLength(75)
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_TOO_LONG)
                .Must(name =>
                    personService.PersonExists(name))
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_DOES_NOT_EXIST);

            RuleFor(x => x.Address)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.ERROR_ADDRESS_CANNOT_BE_EMPTY)
                .MaximumLength(150)
                    .WithMessage(ValidationErrorMessages.ERROR_ADDRESS_TOO_LONG);
        }
    }
}
