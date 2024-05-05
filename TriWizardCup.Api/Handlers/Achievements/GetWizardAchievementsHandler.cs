using AutoMapper;
using MediatR;
using TriWizardCup.Api.Queries.Achievements;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Handlers.Achievements
{
    public class GetWizardAchievementsHandler : BaseHandler, IRequestHandler<GetWizardsAchievementsQuery, WizardAchievementResponse?>
    {
        public GetWizardAchievementsHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<WizardAchievementResponse?> Handle(GetWizardsAchievementsQuery request, CancellationToken cancellationToken)
        {
            var wizardAchievements = await _unitOfWork.Achievements.GetWizardAchievementAsync(request.WizardId);

            if (wizardAchievements is null)
                return null;

            return _mapper.Map<WizardAchievementResponse?>(wizardAchievements);
        }
    }
}
