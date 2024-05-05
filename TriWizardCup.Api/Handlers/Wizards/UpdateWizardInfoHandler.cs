using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands.Wizards;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;

namespace TriWizardCup.Api.Handlers.Wizards
{
    public class UpdateWizardInfoHandler : BaseHandler, IRequestHandler<UpdateWizardInfoRequest, bool>
    {
        public UpdateWizardInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(UpdateWizardInfoRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Wizard>(request.UpdateRequest);

            await _unitOfWork.Wizards.Update(result);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
