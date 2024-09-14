using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Interfaces;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Queries.GetAccounts;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<AccountDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAccountsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AccountDTO>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _unitOfWork.AccountRepository.GetAllAsync();

        return accounts.Select(AccountDTO.FromAccount);
    }
}