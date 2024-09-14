using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.Email) ?? throw new NotFoundException(nameof(Contact), request.Email);

        contact.FirstName = request.FirstName;
        contact.LastName = request.LastName;

        await _unitOfWork.ContactRepository.UpdateAsync(contact);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
