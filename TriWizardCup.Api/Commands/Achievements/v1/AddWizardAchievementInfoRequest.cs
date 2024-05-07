using MediatR;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses.v1;

namespace TriWizardCup.Api.Commands.Achievements.v1
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
