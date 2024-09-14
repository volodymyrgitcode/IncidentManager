using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Queries.GetContact;

public record GetContactQuery : IRequest<ContactDTO>
{
    public required string Email { get; init; }
}