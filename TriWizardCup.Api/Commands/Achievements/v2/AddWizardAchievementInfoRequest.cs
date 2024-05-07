using MediatR;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses.v2;

namespace TriWizardCup.Api.Commands.Achievements.v2
{
    public class AddWizardAchievementInfoRequest : IRequest<WizardAchievementResponse>
    {
        public CreateWizardAchievementRequest AchievementRequest { get; }

        public AddWizardAchievementInfoRequest(CreateWizardAchievementRequest achievementRequest)
        {
            AchievementRequest = achievementRequest;
        }
    }
}
