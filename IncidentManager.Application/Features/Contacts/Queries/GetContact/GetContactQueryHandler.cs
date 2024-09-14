using IncidentManager.Application.Common.DTOs;
using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Queries.GetContact;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ContactDTO> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactRepository.GetByEmailAsync(request.Email) ?? throw new NotFoundException(nameof(Contact), request.Email);

        return ContactDTO.FromContact(contact);
    }
}
