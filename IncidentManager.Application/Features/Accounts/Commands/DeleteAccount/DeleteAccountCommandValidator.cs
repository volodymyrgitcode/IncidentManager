using FluentValidation;

namespace IncidentManager.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(x => x.Name)
         .Length(2, 50).WithMessage("Account Name length is invalid.");    
    }
}
