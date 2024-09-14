using MediatR;

namespace IncidentManager.Application.Features.Contacts.Commands.UpdateContact;

public record UpdateContactCommand : IRequest
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}