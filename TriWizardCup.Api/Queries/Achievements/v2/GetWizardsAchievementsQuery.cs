using MediatR;
using TriWizardCup.Entities.Dtos.Responses.v2;

namespace TriWizardCup.Api.Queries.Achievements.v2
{
    public class GetWizardsAchievementsQuery : IRequest<WizardAchievementResponse?>
    {
        public Guid WizardId { get; }

        public GetWizardsAchievementsQuery(Guid wizardId)
        {
            WizardId = wizardId;
        }
    }
}
