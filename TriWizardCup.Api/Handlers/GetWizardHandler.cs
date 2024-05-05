using AutoMapper;
using MediatR;
using TriWizardCup.Api.Queries;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Handlers
{
    public class GetWizardHandler : BaseHandler, IRequestHandler<GetWizardQuery, GetWizardResponse?>
    {
        public GetWizardHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<GetWizardResponse?> Handle(GetWizardQuery request, CancellationToken cancellationToken)
        {
            var wizard = await _unitOfWork.Wizards.GetById(request.WizardId);

            if (wizard is null)
                return null;

            return _mapper.Map<GetWizardResponse?>(wizard);
        }
    }
}
