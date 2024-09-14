using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.Email) ?? throw new NotFoundException(nameof(Contact), request.Email);

        await _unitOfWork.ContactRepository.DeleteAsync(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
