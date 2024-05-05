using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries.Achievements
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
