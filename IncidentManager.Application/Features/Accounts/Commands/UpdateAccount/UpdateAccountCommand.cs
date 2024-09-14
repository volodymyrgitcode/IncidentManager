using MediatR;

namespace IncidentManager.Application.Features.Accounts.Commands.UpdateAccount;

public record UpdateAccountCommand : IRequest
{
    public string Name { get; init; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
}