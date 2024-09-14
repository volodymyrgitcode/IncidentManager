using FluentValidation;
using IncidentManager.Application.Common.Interfaces;

namespace IncidentManager.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAccountCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Name)
          .Length(2, 50).WithMessage("Account Name length is invalid.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().MaximumLength(100).WithMessage("A valid email is required.")
            .MustAsync(ContactMustNotBeLinkedToAnotherAccount).WithMessage("The contact email is unavailable");
    }

    private async Task<bool> ContactMustNotBeLinkedToAnotherAccount(string contactEmail, CancellationToken cancellationToken)
    {
        var existingContact = await _unitOfWork.ContactRepository.GetByIdAsync(contactEmail);
        return existingContact != null && string.IsNullOrEmpty(existingContact.AccountName);
    }
}
