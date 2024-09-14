using FluentValidation;

namespace IncidentManager.Application.Features.Incidents.Commands.UpdateIncident;

public class UpdateIncidentCommandValidator : AbstractValidator<UpdateIncidentCommand>
{
    public UpdateIncidentCommandValidator()
    {
        RuleFor(x => x.AccountName)
            .NotEmpty().WithMessage("Account Name is required.")
            .Length(3, 50).WithMessage("Account Name length is invalid.");

        RuleFor(x => x.ContactFirstName)
            .NotEmpty().WithMessage("Contact First Name is required.")
            .Length(2, 30).WithMessage("Contact First Name length is invalid.");

        RuleFor(x => x.ContactLastName)
            .NotEmpty().WithMessage("Contact Last Name is required.")
            .Length(2, 30).WithMessage("Contact Last Name length is invalid.");

        RuleFor(x => x.ContactEmail)
            .NotEmpty().WithMessage("Contact Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(100).WithMessage("Contact Email length is invalid.");

        RuleFor(x => x.IncidentDescription)
            .NotEmpty().WithMessage("Incident description is required.")
            .MaximumLength(500).WithMessage("Incident description is too long.");
    }
}