using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Queries.GetAccount;

public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAccountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AccountDTO> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.AccountRepository.GetByNameAsync(request.Name) ?? throw new NotFoundException(nameof(Account), request.Name);

        return AccountDTO.FromAccount(account);
    }
}
