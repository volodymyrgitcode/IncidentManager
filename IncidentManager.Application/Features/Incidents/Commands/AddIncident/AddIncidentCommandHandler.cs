using IncidentManager.Application.Common.Exceptions;
using IncidentManager.Application.Common.Interfaces;
using IncidentManager.Domain.Entities;
using MediatR;

namespace IncidentManager.Application.Features.Incidents.Commands.AddIncident;

public class AddIncidentCommandHandler : IRequestHandler<AddIncidentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddIncidentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddIncidentCommand request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(request.AccountName) ?? throw new NotFoundException(nameof(Account), request.AccountName);

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

        var incident = new Incident
        {
            Description = request.IncidentDescription,
            Accounts = new List<Account> { account }
        };

        await _unitOfWork.IncidentRepository.AddAsync(incident);

        account.IncidentName = incident.IncidentName;
        await _unitOfWork.AccountRepository.UpdateAsync(account);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
