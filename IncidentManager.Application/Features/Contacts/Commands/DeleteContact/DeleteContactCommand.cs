using MediatR;

namespace IncidentManager.Application.Features.Contacts.Commands.DeleteContact;

public record DeleteContactCommand : IRequest
{
    public required string Email { get; init; }
}