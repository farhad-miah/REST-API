using AutoMapper;
using TriWizardCup.DataService.Repositories.Interfaces;

namespace TriWizardCup.Api.Handlers
{
    public class BaseHandler
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
