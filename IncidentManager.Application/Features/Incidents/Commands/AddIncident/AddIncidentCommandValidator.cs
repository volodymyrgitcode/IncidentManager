using FluentValidation;

namespace IncidentManager.Application.Features.Incidents.Commands.AddIncident;

public class AddIncidentCommandValidator : AbstractValidator<AddIncidentCommand>
{
    public AddIncidentCommandValidator()
    {
        RuleFor(x => x.AccountName)
            .Length(3, 50).WithMessage("Account Name length is invalid.");

        RuleFor(x => x.ContactFirstName)
            .Length(2, 30).WithMessage("Contact First Name length is invalid.");

        RuleFor(x => x.ContactLastName)
            .Length(2, 30).WithMessage("Contact Last Name length is invalid.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.");

        RuleFor(x => x.IncidentDescription)
            .Length(2,500).WithMessage("Incident description length is invalid.");
    }
}