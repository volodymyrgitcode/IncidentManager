using IncidentManager.Application.Common.DTOs;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Queries.GetContacts;

public record GetContactsQuery : IRequest<IEnumerable<ContactDTO>>
{
}