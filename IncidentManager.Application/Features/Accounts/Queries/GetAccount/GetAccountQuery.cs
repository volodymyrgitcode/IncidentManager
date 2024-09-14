using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Accounts.Queries.GetAccount;

public record GetAccountQuery : IRequest<AccountDTO>
{
    public required string Name { get; init; }
}