using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TriWizardCup.Entities.Dtos.Responses.v1;

namespace TriWizardCup.Api.Queries.Achievements.v1
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
