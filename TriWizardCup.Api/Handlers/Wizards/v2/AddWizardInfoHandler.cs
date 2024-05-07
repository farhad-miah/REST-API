using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands.Wizards.v2;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Handlers.Wizards.v2
{
    public class AddWizardInfoHandler : BaseHandler, IRequestHandler<CreateWizardInfoRequest, GetWizardResponse>
    {
        public AddWizardInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<GetWizardResponse> Handle(CreateWizardInfoRequest request, CancellationToken cancellationToken)
        {
            var wizard = _mapper.Map<Wizard>(request.WizardRequest);

            await _unitOfWork.Wizards.Add(wizard);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<GetWizardResponse>(wizard);
        }
    }
}
