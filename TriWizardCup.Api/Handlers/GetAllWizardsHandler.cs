using AutoMapper;
using MediatR;
using TriWizardCup.Api.Queries;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Handlers
{
    public class GetAllWizardsHandler : IRequestHandler<GetAllWizardsQuery, IEnumerable<GetWizardResponse>>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GetAllWizardsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetWizardResponse>> Handle(GetAllWizardsQuery request, CancellationToken cancellationToken)
        {
            var wizards = await _unitOfWork.Wizards.All();

            return _mapper.Map<IEnumerable<GetWizardResponse>>(wizards);
        }
    }
}
