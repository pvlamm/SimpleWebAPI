namespace SimpleWebAPI.Application.Person.Commands
{
    using FluentValidation;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Application.Common.Messages;

    public class DeletePersonValidation : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonValidation(IPersonService personService)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_CANNOT_BE_EMPTY)
                .Must(name =>
                    !personService.PersonExists(name))
                    .WithMessage(ValidationErrorMessages.ERROR_NAME_DOES_NOT_EXIST);
        }
    }
}
