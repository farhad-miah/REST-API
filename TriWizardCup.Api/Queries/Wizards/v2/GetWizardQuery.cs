using MediatR;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries.Wizards.v2
{
    public class GetWizardQuery : IRequest<GetWizardResponse?>
    {
        public Guid WizardId { get; }

        public GetWizardQuery(Guid wizardId)
        {
            WizardId = wizardId;
        }
    }
}
