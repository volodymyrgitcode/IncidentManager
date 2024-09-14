using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Commands.AddContact;

public class AddContactCommandHandler : IRequestHandler<AddContactCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddContactCommand request, CancellationToken cancellationToken)
    {
        var existingContact = _unitOfWork.ContactRepository.GetByIdAsync(request.Email);

        if (existingContact != null)
        {
            throw new AlreadyExistsException($"The contact already exists.");
        }

        var contact = new Contact 
        {   FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
        };

        await _unitOfWork.ContactRepository.AddAsync(contact);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
