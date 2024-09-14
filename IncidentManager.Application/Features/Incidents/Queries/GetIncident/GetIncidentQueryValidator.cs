using FluentValidation;

namespace IncidentManager.Application.Features.Incidents.Queries.GetIncident;

public class GetIncidentQueryValidator : AbstractValidator<GetIncidentQuery>
{
    public GetIncidentQueryValidator()
    {
        RuleFor(x => x.IncidentName)
            .NotEmpty().WithMessage("Incident Name is required.");
    }
}