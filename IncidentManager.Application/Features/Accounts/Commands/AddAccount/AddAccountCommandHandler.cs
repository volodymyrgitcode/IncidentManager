using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Commands.AddAccount;

public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account { Name = request.Name };

        var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.ContactEmail);

        contact!.AccountName = account.Name;

        await _unitOfWork.ContactRepository.UpdateAsync(contact);

        await _unitOfWork.AccountRepository.AddAsync(account);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
