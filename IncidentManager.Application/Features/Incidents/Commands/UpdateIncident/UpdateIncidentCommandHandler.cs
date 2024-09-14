using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.UpdateIncident;

public class UpdateIncidentCommandHandler : IRequestHandler<UpdateIncidentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateIncidentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateIncidentCommand request, CancellationToken cancellationToken)
    {
        var incident = await _unitOfWork.IncidentRepository.GetByIncidentNameAsync(request.IncidentName);

        if (incident is null)
        {
            throw new NotFoundException(nameof(incident), request.IncidentName);
        }

        var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.AccountName);

        if (account is null)
        {
            throw new NotFoundException(nameof(account), request.AccountName);
        }

        var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.ContactEmail);
        if (contact is null)
        {
            contact = new Contact
            {
                Email = request.ContactEmail,
                FirstName = request.ContactFirstName,
                LastName = request.ContactLastName,
                AccountName = account.Name
            };
            await _unitOfWork.ContactRepository.AddAsync(contact);
        }
        else
        {
            contact.FirstName = request.ContactFirstName;
            contact.LastName = request.ContactLastName;
            if (contact.AccountName != account.Name)
            {
                contact.AccountName = account.Name;
            }
            await _unitOfWork.ContactRepository.UpdateAsync(contact);
        }

        incident.Description = request.IncidentDescription;
        incident.Accounts = new List<Account> { account };

        await _unitOfWork.IncidentRepository.UpdateAsync(incident);

        account.IncidentName = incident.IncidentName;
        await _unitOfWork.AccountRepository.UpdateAsync(account);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}