using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriWizardCup.DataService.Repositories.Interfaces;

namespace TriWizardCup.Api.Controllers.v2
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
