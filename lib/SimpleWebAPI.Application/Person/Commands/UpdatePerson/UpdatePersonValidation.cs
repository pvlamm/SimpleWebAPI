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
                .Must(name =>
                    personService.PersonExists(name))
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_DOES_NOT_EXIST);
        }
    }
}
