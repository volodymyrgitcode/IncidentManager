using FluentValidation;

namespace IncidentManager.Application.Features.Contacts.Queries.GetContact;

public class GetContactQueryValidator : AbstractValidator<GetContactQuery>
{
    public GetContactQueryValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.");
    }
}