using MediatR;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Commands.Achievements
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
