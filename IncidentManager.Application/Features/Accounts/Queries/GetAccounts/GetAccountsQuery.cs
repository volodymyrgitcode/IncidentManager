using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Queries.GetAccounts;

public record GetAccountsQuery : IRequest<IEnumerable<AccountDTO>>
{
}