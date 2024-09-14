using FluentValidation;

namespace IncidentManager.Application.Features.Incidents.Commands.DeleteIncident;

public class DeleteIncidentCommandValidator : AbstractValidator<DeleteIncidentCommand>
{
    public DeleteIncidentCommandValidator()
    {
        RuleFor(x => x.IncidentName)
            .NotEmpty().WithMessage("Incident Name is required.");
    }
}