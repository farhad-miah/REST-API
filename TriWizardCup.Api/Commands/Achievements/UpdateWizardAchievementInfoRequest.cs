using MediatR;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.Commands.Achievements
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
