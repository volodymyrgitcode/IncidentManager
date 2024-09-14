using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Interfaces;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Queries.GetContacts;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ContactDTO>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _unitOfWork.ContactRepository.GetAllAsync();

        return contacts.Select(ContactDTO.FromContact);
    }
}