using MediatR;

namespace IncidentManager.Application.Features.Accounts.Commands.DeleteAccount;

public record DeleteAccountCommand : IRequest
{
    public string Name { get; init; } = string.Empty;
}