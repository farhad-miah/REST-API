using MediatR;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.Commands.Achievements.v2
{
    public class UpdateWizardAchievementInfoRequest : IRequest<bool>
    {
        public UpdateWizardAchievementRequest UpdateRequest { get; }

        public UpdateWizardAchievementInfoRequest(UpdateWizardAchievementRequest updateRequest)
        {
            UpdateRequest = updateRequest;
        }
    }
}
