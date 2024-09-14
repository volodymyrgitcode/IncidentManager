using MediatR;

namespace IncidentManager.Application.Features.Accounts.Commands.AddAccount;

public record AddAccountCommand : IRequest
{
    public string Name { get; init; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
}