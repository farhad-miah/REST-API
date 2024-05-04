using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Handlers
{
    public class AddWizardInfoHandler : IRequestHandler<CreateWizardInfoRequest, GetWizardResponse>
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public AddWizardInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
