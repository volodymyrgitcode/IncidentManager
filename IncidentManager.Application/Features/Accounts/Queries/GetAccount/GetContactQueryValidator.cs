using FluentValidation;

namespace IncidentManager.Application.Features.Accounts.Queries.GetAccount;

public class GetContactQueryValidator : AbstractValidator<GetAccountQuery>
{
    public GetContactQueryValidator()
    {
        RuleFor(x => x.Name)
        .Length(2, 50).WithMessage("Account Name length is invalid.");
    }
}