using FluentValidation;

namespace IncidentManager.Application.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.");
    }
}