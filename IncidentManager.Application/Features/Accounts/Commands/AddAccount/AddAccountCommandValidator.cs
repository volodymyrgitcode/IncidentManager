using FluentValidation;
using IncidentManager.Application.Common.Interfaces;

namespace IncidentManager.Application.Features.Accounts.Commands.AddAccount;

public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddAccountCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Name)
          .Length(2, 50).WithMessage("Account Name length is invalid.")
          .MustAsync(AccountMustNotExist).WithMessage("The account already exists.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.")
            .MustAsync(ContactMustNotBeLinkedToAnotherAccount).WithMessage("The contact email is unavailable");
    }

    private async Task<bool> AccountMustNotExist(string accountName, CancellationToken cancellationToken)
    {
        var existingAccount = await _unitOfWork.AccountRepository.GetByIdAsync(accountName);
        return existingAccount == null;
    }

    private async Task<bool> ContactMustNotBeLinkedToAnotherAccount(string contactEmail, CancellationToken cancellationToken)
    {
        var existingContact = await _unitOfWork.ContactRepository.GetByIdAsync(contactEmail);
        return existingContact != null && string.IsNullOrEmpty(existingContact.AccountName);
    }
}