using FluentValidation;

namespace IncidentManager.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.FirstName)
           .Length(2, 30).WithMessage("Contact First Name length is invalid.");

        RuleFor(x => x.LastName)
            .Length(2, 30).WithMessage("Contact Last Name length is invalid.");

        RuleFor(x => x.Email)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.");
    }
}