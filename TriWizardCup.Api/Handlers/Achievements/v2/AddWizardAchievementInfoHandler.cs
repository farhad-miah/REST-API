using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands.Achievements.v2;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Responses.v2;

namespace TriWizardCup.Api.Handlers.Achievements.v2
{
    public class AddWizardAchievementInfoHandler : BaseHandler, IRequestHandler<AddWizardAchievementInfoRequest, WizardAchievementResponse>
    {
        public AddWizardAchievementInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<WizardAchievementResponse> Handle(AddWizardAchievementInfoRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Achievement>(request.AchievementRequest);

            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<WizardAchievementResponse>(result);
        }
    }
}
