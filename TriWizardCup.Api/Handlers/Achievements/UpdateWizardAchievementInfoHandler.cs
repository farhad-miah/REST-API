using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands.Achievements;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;

namespace TriWizardCup.Api.Handlers.Achievements
{
    public class UpdateWizardAchievementInfoHandler : BaseHandler, IRequestHandler<UpdateWizardAchievementInfoRequest, bool>
    {
        public UpdateWizardAchievementInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(UpdateWizardAchievementInfoRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Achievement>(request.UpdateRequest);

            await _unitOfWork.Achievements.Update(result);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
