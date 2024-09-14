using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.Name) ?? throw new NotFoundException(nameof(Account), request.Name);

        account.Name = request.Name;

        var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.ContactEmail);
        contact!.AccountName = account.Name;
        await _unitOfWork.ContactRepository.UpdateAsync(contact);

        await _unitOfWork.AccountRepository.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();
    }
}
